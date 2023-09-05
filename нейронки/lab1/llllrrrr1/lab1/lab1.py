
def activate(amount):
    if amount >= 0.5:
        return True
    return False


def menu():
    input_data = [1, 0, 1, 1, 0]
    hidden_layer = [[0.6, 0.7, 0.8, 0, 0], [0.01, -0.02, 0.5,  0.01, 0.5]]
    activate_hidden_layer = [1, -1]
    something = []
    amount = 0
    for i in range(2):
        for j in range(5):
            amount += input_data[j] * hidden_layer[i][j] #1.5 AND 0.5
        if activate(amount):
            something.append(1) # 1 AND 1
        else:
            something.append(0)
        amount = 0

    for i in range(2):
        amount += something[i] * activate_hidden_layer[i]

    if activate(amount):
        print("Идем играть в настолки")
    else:
        print("Не идем играть в настолки );")


menu()
