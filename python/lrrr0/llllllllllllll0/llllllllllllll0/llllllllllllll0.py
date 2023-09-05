from math import*
print('enter outer radius: ')
R = int(input())
print('enter inner radius: ')
r = int(input())


S = pi * (R**2-r**2);

print('result = ','% .3f '% S)