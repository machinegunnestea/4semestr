import numpy as np
from math import *
import matplotlib.pyplot as plt

def main():
    task1()

def f1(x):
    return x**2 +25*x +8

def task1():
    a = 0
    b = 6
    eps = 0.1
    x = np.linspace(a, b, 50)
    y = f1(x)
    (fig, ax) = plt.subplots()
    ax.grid()
    plt.xlabel('x', fontsize=14)
    plt.ylabel('y', fontsize=14)
    ax.plot(x, y, color = 'blue')
    (x_max, y_max, iteration_counter) = golden_section_method(f1, a, b, eps)
    print('Метод золотого сечения:')
    print('Точка экстремума - (%f; %f)\nКол-во итераций - %d' %(x_max, y_max, iteration_counter))
    plt.plot(x_max, y_max, marker = 'o', color = 'green', label='Метод золотого сечения')
    (x_max, y_max, iteration_counter) = method_fibonacci(f1, a, b, eps)
    print('\nМетод чисел Фибоначчи:')
    print('Точка экстремума - (%f; %f)\nКол-во итераций - %d' %(x_max, y_max, iteration_counter))
    plt.plot(x_max, y_max, marker = 'o', color = 'red', label='Метод чисел Фибоначчи')
    ax.legend()
    plt.show()

def golden_section_method(f, a, b, eps):
    PHI = (1 + np.sqrt(5)) / 2
    iteration_counter = 0
    while (True):
        iteration_counter += 1
        x1 = b - (b - a) / PHI
        x2 = a + (b - a) / PHI
        y1 = f(x1)
        y2 = f(x2)
        if (y1 >= y2):
            a = x1
        else:
            b = x2
        if (abs(b - a) < eps):
            x = (a + b) / 2
            break
    return (x, f(x), iteration_counter)

def method_fibonacci(f, a, b, eps):
    Fn = abs(b - a) / eps
    number_of_iterations = 100
    fibonacci_numbers = get_fibonacci_numbers(number_of_iterations)
    n = 0
    for i in fibonacci_numbers:
        n += 1
        if (Fn < i):
            break
    iteration_counter = n
    while (True):
        x1 = a + (b - a) * fibonacci_numbers[n - 2] / fibonacci_numbers[n]
        x2 = a + (b - a) * fibonacci_numbers[n - 1] / fibonacci_numbers[n]
        y1 = f(x1)
        y2 = f(x2)
        n = n - 1
        if (y1 > y2):
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
        if (n == 1):
            x = (x1 + x2) / 2
            break
    return (x, f(x), iteration_counter)

def get_fibonacci_numbers(quantity):
    numbers = [1, 1]
    iter = 2
    while (iter <= quantity):
        numbers.append(numbers[iter - 1] + numbers[iter - 2])
        iter += 1
    return numbers

main()
