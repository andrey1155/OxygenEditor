
BUFFER = []


def print_to_buff(msg):
    BUFFER.append(msg.__repr__())


def print_buff():
    for i in BUFFER:
        print(i)