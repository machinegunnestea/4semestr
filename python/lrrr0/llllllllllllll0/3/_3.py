from math import *
xn=-10
xk=4
dx=2
x=xn
while x<xk:
    if (x > 2):
        y = sqrt(x)
    elif (x>=-10) and (x<=-3):
        y=x**2/2
    else:
        y=2*x
    print('using x=','%.0f'%x)
    print('result х=','%.3f'%y)
    x=x+dx
