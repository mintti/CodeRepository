# PlayerPrefs 테스트

### 개요

PlayerPrefs 데이타가 MuMuPlayer에서 저장되지 않는 이슈 분석

- 작성일자
    - 240812

---

### 분석

- 추측
    - 디렉터리가 이상하게 설정되어 있음
    - Chat GPT 답변
        - 권한 이슈일 수 있다고 함

- 저장 경로
    - Windows PlayerPrefs 저장 위치
        - registry ‘HKEY_CURRENT_USER\Software\[company name]\[product name]’
        - 참고 : [http://docs.unity3d.com/ScriptReference/PlayerPrefs.html](http://docs.unity3d.com/ScriptReference/PlayerPrefs.html)
    - // 모르겠음

### 테스트

- 간단한 프로젝트 만들어서 테스트
    - 윈도우/블루스택/뮤뮤에서 값이 잘 저장됨
- 차이 분석
    - PlayerPrafs.Set[Type]() 만 사용
        - 해당 함수로 값을 설정하면 윈도우, 블루 스택에선 값이 등록됨
        - 뮤뮤에서는 값을 읽어오지 못함
    - 추가로 PlayerPrafs.Save() 호출
        - 뮤뮤 플레이어에서도 값이 잘 저장/열기됨

---

### 해결 ?

- PlayerPrafs.Save() 로직을 추가로 작성해서 빌드해볼 것