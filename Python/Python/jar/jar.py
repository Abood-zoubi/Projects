class Jar:
    def __init__(self, capacity=12):
        if capacity < 0:
            raise ValueError("Can't Go Below 0 ")

        self._size = 0
        self._capacity = capacity

    def __str__(self):
        return self.size * "🍪"

    def deposit(self, n):
        if n < self.capacity:
            if self.size < self.capacity:
                if (self.size + n) <= self.capacity:
                    self._size += n
        else:
            raise ValueError("Exceeds Capacity")

    def withdraw(self, n):
        if self.size < n:
            if (self.size - n) < 0:
               raise ValueError("Nope")

        else:
            self._size -= n

    @property
    def capacity(self):
        return self._capacity

    @property
    def size(self):
        return self._size

jar = Jar()
jar.deposit(11)
jar.withdraw(1)
print(jar)