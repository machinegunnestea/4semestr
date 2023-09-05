
import matplotlib.pyplot as plt
import numpy as np


def f(x):
    return x**2 +25*x +8


def FibonacciNumber(n):
    if (n == 0):
        return 0
    if n in (1, 2):
        return 1
    return FibonacciNumber(n - 1) + FibonacciNumber(n - 2)


def Fibonacci(a, b, eps):
    n = 2
    while (np.fabs(b - a) > eps):
        x1 = a + (b - a) * FibonacciNumber(n - 2) / FibonacciNumber(n)
        x2 = a + (b - a) * FibonacciNumber(n - 1) / FibonacciNumber(n)
        y1 = f(x1)
        y2 = f(x2)
        n = n + 1
        if (y1 < y2):
            a = x1
            x1 = x2
            x2 = b - (x1 - a)
            y1 = y2
            y2 = f(x2)
        else:
            b = x2
            x2 = x1
            x1 = a + (b - x2)
            y2 = y1
            y1 = f(x1)
    return (x1 + x2) / 2, n


def GoldenRatio(a, b, eps):
    n = 0
    while (np.fabs(b - a) > eps):
        n = n + 1
        x1 = b - (b - a) / fi
        x2 = a + (b - a) / fi
        if (f(x1) <= f(x2)):
            a = x1
        else:
            b = x2
    return (a + b) / 2, n


a = 0
b = 6
eps = 0.001
n = 10
fi = (1 + np.sqrt(5)) / 2
min, nmin = GoldenRatio(a, b, eps)
fmin, fnmin = Fibonacci(a, b, eps)
print(f"Золотое сечение:\nmax = {min}, Число итераций = {nmin}")
print(f"\nФибоначчи:\nmax = {fmin}, Число итераций = {fnmin}")
x = np.arange(a, b, eps)
plt.plot(x, f(x))
plt.plot(min, f(min), 'ro', label='Золотое сечение', color="red")
plt.plot(fmin, f(min), 'go', label='Фибоначчи', color="black")
plt.grid()
plt.legend()
plt.show()
