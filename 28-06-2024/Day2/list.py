from collections import deque
queue = deque([1,2,3])
queue.append(4)  
print(queue) 

queue.appendleft([6,7])
print(queue)

queue.extendleft([6,7])
print(queue)

queue.popleft()
print(queue)

queue.rotate(3)
print(queue)