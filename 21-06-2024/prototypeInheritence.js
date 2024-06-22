//prototype parent obj
const shape = {
    displayDetails: function() {
      console.log(`This is the shape prototype!`);
    }
};
  
//child obj
const circle = {
    shapeName: 'Circle Shape'
};
  
//prototype inheritance
circle.__proto__ = shape;

console.log(circle.shapeName)
circle.displayDetails()