# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.


def test_set(hidden_out_w, input_hidden_w):
    data_file = open('mnist_train.csv', 'r')
    trening_list = data_file.readlines()
    data_file.close()
    for record in trening_list:
        all_values = record.aplit(',')
        inputs = (numpy.asfarray(all_values[1:])/255.0*0.99)+0.01
        targets = numpy.zeros(10)+0.01
        targets[int(all_values[0])] = 0.99
