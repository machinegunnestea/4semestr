import math

import numpy as np
from math import*
import matplotlib.pyplot as plt


def main():
    task1()


def f1(x, y):
    return -math.sqrt(y**2+x**2)/x


def euler_method(f, xn, xk, yn, h):
    steps = int((xk - xn) / h) + 1
    x = np.linspace(xn, xk, steps)
    y = np.zeros(steps)
    y[1] = yn
    for i in range(1, steps):
        y[i] = y[i - 1] + h * f(x[i - 1], y[i - 1])
    return (x, y)


def runge_kutta_method(f, xn, xk, yn, h):
    steps = int((xk - xn) / h) + 1
    x = np.linspace(xn, xk, steps)
    y = np.zeros(steps)
    y[1] = yn
    for i in range(1, steps):
        k1 = f(x[i - 1], y[i - 1])
        k2 = f(x[i - 1] + h / 2, y[i - 1] + (h * k1) / 2)
        k3 = f(x[i - 1] + h / 2, y[i - 1] + (h * k2) / 2)
        k4 = f(x[i - 1] + h, y[i - 1] + h * k3)
        y[i] = y[i - 1] + (h * (k1 + 2 * k2 + 2 * k3 + k4)) / 6
    return (x, y)


def task1():
    xn = 0
    xk = 1
    yn = 1
    h = 0.2
    (x, y) = euler_method(f1, xn, xk, yn, h)
    print("Метод Эйлера (0.2): ", euler_method(f1, xn, xk, yn, h))
    (fig, ax) = plt.subplots()
    plt.xlabel('x', fontsize=14)
    plt.ylabel('y', fontsize=14)
    plt.grid()
    ax.plot(x, y, color="blue", label="Метод Эйлера с шагом 0.2")
    plt.axhline(0, color="black", linestyle='-')
    h = 0.2
    (x, y) = runge_kutta_method(f1, xn, xk, yn, h)
    ax.plot(x, y, color="orange", label="Метод Рунге-Кутта с шагом 0.2")
    h = 0.1
    (x, y) = euler_method(f1, xn, xk, yn, h)
    ax.plot(x, y, color="green", label="Метод Эйлера с шагом 0.1")
    ax.legend()
    plt.show()


main()