#метод хорд
from math import*
import numpy as np
import matplotlib.pyplot as plt
a = 3
b = 5
num = [0]

def f(x):
    return 0.5*x**4 - 1.1*x**3 - 7*x**2 + 13.7*x - 6.6

def findRoot(xn, xk):
    a = xn
    b = xk
    eps = 0.00001
    while abs(b - a) > eps:
        a = b - (b - a) * f(b) / (f(b) - f(a))
        b = a + (a + b) * f(a) / (f(a) - f(b))
    return b

for i in range(1):
    print(findRoot(a, b))
    num += [findRoot(a, b)]
x = np.arange(3.25, 5.2, 0.0001)
plt.plot(x, f(x), 'y')
for i in range(1, len(num)):
    plt.plot(num[i], f(num[i]), 'ro')
plt.grid()
plt.show()

