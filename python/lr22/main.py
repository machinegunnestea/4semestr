import numpy as np
import matplotlib.pyplot as plt


def amount(mass, exp):
    sum = 0
    for i in range(0, len(mass)):
        sum += pow(mass[i], exp)
    return sum


def multiply(mass1, mass2):
    mult = 0
    for i in range(0, len(mass1)):
        mult += mass1[i] * mass2[i]
    return mult

def approximateFunctionQuadro(T, a, b, c):
    value = (-b+np.sqrt(abs(4*a*(c-T))))/(2*a)

    return value


def main():
    x_array = [1, 2, 3, 3.2, 3.6, 4, 5, 5.9, 6, 7.3]
    y_array = [550, 640, 704, 719, 735, 756, 810, 855, 865, 924]
    n = len(x_array);  # Кол=во опытных измерений.
    sumx = amount(x_array, 1)
    sumx2 = amount(x_array, 2)
    sumx3 = amount(x_array, 3)
    sumx4 = amount(x_array, 4)
    sumy = amount(y_array, 1)
    sumxy = multiply(x_array, y_array)
    sumx2y = 0;
    plt.grid()

    for i in range(0, n):  # подсчёт
        sumx2y += x_array[i] * x_array[i] * y_array[i]

    M2 = np.array([[float(sumx4), float(sumx3), float(sumx2)],
                   [float(sumx3), float(sumx2), float(sumx)],
                   [float(sumx2), float(sumx), float(len(x_array))]])
    v2 = np.array([float(sumx2y), float(sumxy), float(sumy)])
    result = np.linalg.solve(M2, v2)
    a = result[0];
    b = result[1];
    c = result[2];
    for i in range(0, n):  # подсчёт
        plt.plot(x_array[i], y_array[i], marker='o', color="red", )
    x_array.insert(1, 1500)
    y_array.insert(1, int(approximateFunctionQuadro(1500, a, b, c)))

    print("\nВремя алгоритма на 1500K " + '%4.2f ' % approximateFunctionQuadro(500, a, b, c) + "\n")
    #print('%4.2f; %4.2f; %4.2f;'%a, b, c)
    x = np.linspace(0, 20, 50)
    y = approximateFunctionQuadro(x, a, b, c)
    plt.plot(x, y, color="blue")
    plt.show()
    print(a, b, c)


main()
