# Define a custom exception class
class CustomError(Exception):
    def __init__(self, message):
        self.message = message
    
    def __str__(self):
        return f'CustomError: {self.message}'

# Raise the custom exception
def example_function(x):
    if x < 0:
        raise CustomError("Number should be positive")
    return x * 2

# Example usage
try:
    result = example_function(-1)
except CustomError as e:
    print(e)
