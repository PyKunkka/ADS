'''
HashTable
'''

def hash_function(key_str, size):
    return sum([ord(c) for c in key_str]) % size

class HashTable:

    def __init__(self, capacity=1000):
        self.capacity = capacity
        self.size = 0
        self._keys = []
        self.data = [[] for _ in range(capacity)]

    def _find_by_key(self, key, find_result_func):
        index = hash_function(key, self.capacity)
        hash_table_cell = self.data[index]
        found_item = None
        for item in hash_table_cell:
            if item[0] == key:
                found_item = item
                break
        return find_result_func(found_item, hash_table_cell)

    def set(self, key, obj):
        def find_result_func(found_item, hash_table_cell):
            if found_item:
                found_item[1] = obj
            else:
                hash_table_cell.append([key, obj])
                self.size += 1
                self._keys.append(key)

        self._find_by_key(key, find_result_func)
        return self

    def get(self, key):
        def find_result_func(found_item, _):
            if found_item:
                return found_item[1]
            else:
                raise KeyError(key)
        return self._find_by_key(key, find_result_func)

    def keys(self):
        return self._keys

    def __setitem__(self, key, value):
        self.set(key, value)

    def __getitem__(self, key):
        return self.get(key)

    def __repr__(self):
        return '{ ' + ', '.join([key + ':' + str(self.get(key)) for key in self._keys]) + ' }'

if __name__ == "__main__":

    ht = HashTable()

    countHash = int(input('Enter count of information.\n'))
    diction = dict(input().split() for i in range(countHash))

    for i in diction:
        diction[i] = int(diction[i])

    print('Hash table without hash: ' + str(diction))

    for i in diction:
        ht.set(str(i), int(hash_function(str(diction[i]),12)))

    keyV = str(input('Write a key.\n'))

    print('Keys in table: ' + str(ht.keys()))
    print('Hash table after hash: ' + str(ht))
    print('Key ' + str(keyV) + ' value: ' + str(ht.get(keyV)))
