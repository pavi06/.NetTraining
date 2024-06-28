#Day2  : Exploration

#String Manipulation (Key function)
    -len()
    -isupper()
    -islower()
    -isdigit()
    -isalnum()
    -isalpha()
    -strip(), rstrip(), lstrip()


List as Stack (LAST IN - FIRST OUT)
    Eg : [1,2,3,4]
    -append() -> add to the end
        - append(5) -> [1,2,3,4,5]
    -pop() -> remove ele from the right end (least recently added)
        -remove 4

List as Queue (FIRST IN - FIRST OUT)
    -import deque and pass list into deque() constructor
    -popleft() -> used to pop from left

    -appendleft(), extendleft() -> add ele to the left
    -rotate(n) -> rotate list for n position

Tuples (ordered, immutable, duplication allowed)
    -Tuple basic
    -unpacking tuple
    -tuple methods
        -index()
        -count()

Set (unordered, immutable, no duplication)
    -set declaration
        -explicit declaration : " {} "
        -set() function

    -usage
        -cannot accessed through index
        -use loop

    -set methods
        -add() -> add single item
        -remove() -> remove an item
        -update() -> add more than one item
        -clear()
        -copy()
        -difference()

Dictionary (mutable, unordered, no duplicates)
    -Key value pairs -> {Key : value}
    -accessed with key, get() , loop

    -dict methods
    -keys() : return keys
    -values() : return values
    -items() : return each item as a tuple
    -setdefault()

