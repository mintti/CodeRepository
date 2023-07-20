
#include <iostream>
#include <list>
using namespace std;
int main()
{
	//https://www.acmicpc.net/problem/10871
	int n, x;
	cin >> n >> x;

	list<int> lt;
	for (int i = 0; i < n; i++)
	{
		int tm;
		cin >> tm;
		if (tm < x)
			lt.push_back(tm);
	}
	
	while(lt.size() > 0)
	{
		cout << lt.front() << " ";
		lt.pop_front();
	}
	return 0;
}
