import numpy as np
import matplotlib.pyplot as plt

def f(x):
    return (np.sin(x-0.65))**2-0.2*x

a = 0
b = 6
x = a
eps = 0.001
DotA = [0]
DotB = [0]
step = 1
while x <= b - step:
    xNext = x + step
    if f(x) * f(xNext) < 0:
        DotA += [x]
        DotB += [xNext]
    x = xNext
list_dop = []
count = 0
for i in range(1, len(DotA)):
    print('Корни на интервале %6.3f ;' %(DotA[i]), '%6.3f' %(DotB[i]))
    a = DotA[i]
    b = DotB[i]
    while b - a > eps:
        t = (a + b) / 2
        if f(t) * f(a) < 0:
            b = t
        else:
            a = t
    list_dop.append(t)
    print('%8.2f' % list_dop[count])
    count += 1

x = np.arange(0, 15, 0.0001)
plt.plot(x, f(x))
for i in range(0, len(list_dop)):
    plt.plot(list_dop[i], f(list_dop[i]), 'ro')
plt.grid()
plt.show()
