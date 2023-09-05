from math import *
tn=0
tk=2
dt=0.2
N=int(tk/dt)+1
t=tn
for i in range(N):
    x=(100/(t**4+1)+1)/8
    y=t**4
    print('При t=','%.3f'%t)
    print('координата х=','%.3f'%x)
    print('координата y=','%.3f'%y)
    t=t+dt