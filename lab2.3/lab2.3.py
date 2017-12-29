''''
Graph
'''

n,m = (int(k) for k in input().split())
g = [tuple(int(k) for k in input().split()) for i in range(m)]
if len(set(g)) == (n * (n - 1)) // 2:
	print('YES')
else:
	print('NO')