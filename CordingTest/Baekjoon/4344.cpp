#include<iostream>
#include<vector>
using namespace std;

struct Array
{
	int * brr;
	int cnt;
	float avg;
};

int main()
{
	//https://www.acmicpc.net/problem/4344
	int n;
	cin >> n;
	
	Array * arr = new Array[n];
	for(int i = 0 ; i < n; i++)
	{
		int m;
		cin >> m;
		arr[i].brr = new int[m];
		arr[i].cnt = m;
		
		int sum = 0;	
		for(int j = 0 ; j < m ; j ++)
		{
			int u;
			cin >> u;
			
			arr[i].brr[j] = u;
			sum += u;
		}
		arr[i].avg = sum / arr[i].cnt;
	}
	
	for(int i = 0 ; i < n; i ++)
	{
		int cnt= 0;
		float avg = arr[i].avg; 
		for(int j = 0 ; j < arr[i].cnt; j++)
		{
			if(avg < arr[i].brr[j])
				cnt ++;
		}
		cout << fixed;
		cout.precision(3);
		cout << (float)cnt / arr[i].cnt * 100 << "%" << endl;
	}
	 
}
