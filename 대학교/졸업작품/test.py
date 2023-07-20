from flask import Flask, request, jsonify
from urllib.request import urlopen, Request
from bs4 import BeautifulSoup
import urllib
import pyrebase
import re

app = Flask(__name__)

config = {
    "apiKey": "AIzaSyB3vxp76TdkB1aU05naTuqBZD8vAP7Cocc",
    "authDomain": "kakao-ymh-subway.firebaseapp.com",
    "databaseURL": "https://kakao-ymh-subway.firebaseio.com",
    "projectId": "kakao-ymh-subway",
    "storageBucket": "kakao-ymh-subway.appspot.com",
   "messagingSenderId": "678961495819",
    "appId": "1:678961495819:web:1cebaf4e47e25d27b42c0e",
    "measurementId": "G-ZX4WJF21DE"
}
firebase = pyrebase.initialize_app(config)
db = firebase.database()

userid = "temp"

#매장찾기 스킬
@app.route('/message', methods=['POST'])
def store():

    content = request.get_json()
    content = content['userRequest']
    content = content['utterance']

    enc_loc = urllib.parse.quote(content + '서브웨이')
    el = str(enc_loc)
    url = 'https://search.naver.com/search.naver'
    url = url + '?sm=top_hty&fbm=1&ie=utf8&query='
    url = url + el

    req = Request(url)
    page = urlopen(req)
    html = page.read()
    soup = BeautifulSoup(html, 'html.parser')
    r1 = soup.find('a', class_='tit _title _sp_each_url _sp_each_title').text
    r2 = soup.find('span', class_='tell').text

    name = "매장이름 : " + r1
    tel = "\n전화번호 : " + r2

    answer = name + tel
    # r2 = r1.find('div', class_='map_num')
    # r3 = r2.find('span').text
    # r3 = r2.find('a', class_='tit_title_sp_each_url_sp_each_title').text
    # r5 = r4.find('span').text


    # if len(location) <= 0:
    #     answer = ERROR_MESSAGE
    # else:
    #     answer = content + "주소 : " + r5


    res = {
        "version": "2.0",
        "data": {
            "name": name,
            "tel" : tel
        }
    }

    return jsonify(res)

#주문 스킬
@app.route('/order', methods=['POST'])
def orderTest():
    
    req = request.get_json()
    sandwich = req["action"]["params"]["sandwich"]
    amount = req["action"]["detailParams"]["amount"]["value"]
    size = req["action"]["params"]["size"]
    bread = req["action"]["params"]["bread"]
    vegetable = req["action"]["params"]["vegetable"]
    sauce = req["action"]["params"]["sauce"]
    setmenu = req["action"]["params"]["setmenu"]
    
    #amount에서 개수만 출력되도록
    num_amount = re.findall(r"[\w']+", amount)
        
    res = {
        "version": "2.0",
        "data": {
            "amount" : num_amount[1] + "개",
            "sauce" : sauce,
            "sandwich" : sandwich,
            "size" : size,
            "bread" : bread,
            "vegetable" : vegetable,
            "setmenu" : setmenu
        }
    }
    
    return jsonify(res)

'''
#기존 userid 존재여부 ㅌ 
@app.route('/classify', methods = ['POST'])
def class_():
    userid = req["userRequest"]["user"]["id"][0:5]
    if(db.child('db').child(userid).get() == Null)
        basket()
    return None
'''

#장바구니 담기 스킬
@app.route('/basket', methods=['POST'])
def basket():
    
    req = request.get_json()
    sandwich = req["action"]["params"]["sandwich"]
    amount = req["action"]["detailParams"]["amount"]["value"]
    size = req["action"]["params"]["size"]
    bread = req["action"]["params"]["bread"]
    vegetable = req["action"]["params"]["vegetable"]
    sauce = req["action"]["params"]["sauce"]
    setmenu = req["action"]["params"]["setmenu"]
    
    #amount에서 개수만 출력되도록
    num_amount = re.findall(r"[\w']+", amount)
    
    #받은 데이터를 장바구니 테이블에 저장
    #장바구니 테이블에 저장된 목록을 불러와서 출력
    
    userid = req["userRequest"]["user"]["id"][0:5]
    
    #db.child("order").child("userid").push(userid)
    db.child('orderlist').child(userid).push(
        {
            "amount" : num_amount[1],
            "sauce" : sauce,
            "sandwich" : sandwich,
            "size" : size,
            "bread" : bread,
            "vegetable" : vegetable,
            "setmenu" : setmenu
        }
    )
    
    res = {
        "version": "2.0",
        "data": {
            "complete": "주문이 장바구니에 담겼습니다.",
            "amount" : num_amount[1] + "개",
            "sauce" : sauce,
            "sandwich" : sandwich,
            "size" : size,
            "bread" : bread,
            "vegetable" : vegetable,
            "setmenu" : setmenu
        }
    }
    
    return jsonify(res)

#장바구니 불러오기 스킬
@app.route('/basket_Get', methods=['POST'])
def basket_Get():
    
    req = request.get_json()
    userid = req["userRequest"]["user"]["id"][0:5]
    
    #user_db = db.child('orderlist').child(userid).ref()

    order = db.child('orderlist').child(userid).get().val()
    
    index = 0
    ordertext = "===장바구니==="
    for k in order:
        ordertext += "\n=== " + str(index+1) + "번째 샌드위치 ==="  
        ordertext += "\n메뉴 : " + order[k]["sandwich"]
        ordertext += "\n수량 : " + order[k]["amount"] + "개"
        ordertext += "\n크기 : " + order[k]["size"]
        ordertext += "\n빵   : " + order[k]["bread"]
        ordertext += "\n야채 : " + order[k]["vegetable"]
        ordertext += "\n소스 : " + order[k]["sauce"]
        ordertext += "\n세트 : " + order[k]["setmenu"]
        ordertext += "\n"
        index += 1
        
    res = {
        "version": "2.0",
        "data": {
            "order" : ordertext
        }
    }
    
    print(ordertext)
    return jsonify(res)

#장바구니 전체 삭제
@app.route('/basket_Reset', methods=['POST'])
def basket_Reset() :
    req = request.get_json()
    userid = req["userRequest"]["user"]["id"][0:5]
    
    db.child('orderlist').child(userid).remove()
    res = {
        "version": "2.0",
        "data": {
            "text": "전체 장바구니를 비웠습니다."
        }
    }
    return jsonify(res)

#장바구니 부분삭제
@app.route('/basket_Part_Reset', methods=['POST'])
def basket_Part_Reset() :
    req = request.get_json()
    userid = req["userRequest"]["user"]["id"][0:5]
    number = req["action"]["detailParams"]["delete"]["value"]
    number_ = re.findall(r"[\w']+", number)
    
    print(number_[1])
    order = db.child('orderlist').child(userid).get().val()
    
    #키값 찾기
    key = "key value"
    index = 0
    for k in order:
        print("수행")
        if index == (int(number_[1]) -1):
            key = k         
            break;
        index+= 1
    
    db.child('orderlist').child(userid).child(key).remove()
    
    res = {
        "version": "2.0",
        "data": {
            "text": str(number_[1]) + "번째 장바구니를 비웠습니다."
        }
    }
    return jsonify(res)

if __name__ == "__main__":
    app.run(host='0.0.0.0', port = 5000)

