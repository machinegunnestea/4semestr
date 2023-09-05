import numpy as np
import matplotlib.pyplot as plt
import math
from sympy import*

def main():
    a = 0
    b = 2
    n = 4
    eps = 1e-5
    x = symbols('x')
    integral_value = integrate(cos(x**2)*x**3, (x, a, b))
    print("Значение интеграла равно - %f" %integral_value)
    right_rectangle_method(f, a, b, n)
    trapezeMethod(a, b, n)
    left_rectangle_method_by_runge(f, a, b, n, eps)

def f(x):
    return np.cos(x**2)*x**3

def right_rectangle_method(f, a, b, n):
    h = (b - a) / n
    xn = a
    xk = b
    x = np.linspace(a - 1, b + 1, 50)
    y = f(x)
    fig, ax = plt.subplots()
    plt.grid()
    ax.plot(x, y, color="blue")
    plt.axvline(a, f(a), color="red", linestyle='-')
    plt.axvline(b, f(b), color="red", linestyle='-')
    plt.axhline(0, color="black", linestyle='-')
    ax.plot(a, f(a), color="red")
    sum = 0
    while xk > xn:
        plt.fill_between([xk, xk - h], [f(xk), f(xk)])
        sum += f(xk)
        xk -= h
    print("Метод правых прямоугольников - %f" %(sum * h))
    plt.show()

def left_rectangle_method_by_runge(f, a, b, n, eps):
    h = (b - a) / n
    x = np.linspace(a - 1, b + 1, 50)
    y = f(x)
    sum = 0
    count_of_iterations = 0
    while True:
        sum_prev = sum
        sum = 0
        xn = a
        xk = b
        while xn < xk:
            sum += f(xn)
            xn += h
        sum *= h
        h /= 2
        if abs(sum - sum_prev) / 3 < eps:
            break
        count_of_iterations += 1
    print("Метод левых прямоугольников по правилу Рунге - %f" %sum)
def trapezeMethod(a, b, n):
    a = np.linspace(a, b, n)
    step = abs(a[1] - a[0])
    amount = 0
    for i in range(len(a) - 1):
        amount += step * (f(a[i]) + f(a[i+1])) / 2
    print("Интеграл методом трапеций равен " + str(amount))


main()
