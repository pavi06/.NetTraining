//student class
class Student{
    constructor(studId, studName, studAge){
        this.studId = studId;
        this.studName = studName;
        this.studAge = studAge;
    }

    displayStudentDetails(){
        return `---------Student Details----------\nStudent Id : ${this.studId}\nStudent Name : ${this.studName}\nStudent Age : ${this.studAge}`;
    }
}

//studentSubjects class extends student class
//Inheritence
class StudentSubjects extends Student{
    constructor(studId, studName,studAge, subCount, subjects, subMarks){
        //calling super class constructor
        super(studId,studName,studAge);
        this.subCount = subCount;
        this.subjects = subjects;
        this.subMarks = subMarks;
    }


    //abstract method
    scorePointsCalculation(){
        throw new Error('abstract method which is not implemented!');
    }

    //polymorphism
    //method with two forms
    displayStudentDetails(){
        return `${super.displayStudentDetails()}Total No Of Subjects : ${this.subCount}\nSubjects : ${this.subjects}\nSubject Marks : ${this.subMarks}`;
    }
}

class StudentPointsCalculation extends StudentSubjects{
    constructor(studId, studName,studAge, subCount, subjects, subMarks){
        //calling super class constructor
        super(studId,studName,studAge, subCount, subjects, subMarks);
        this.totalMarks=0;
        this.points=0;
    }

    //abstract method implementation
    pointsCalculation(){
        this.subMarks.forEach(mark => {
            this.totalMarks += mark;
        });
        this.points = (this.totalMarks/this.subCount/10).toFixed(2);
    }

    displayStudentPoints(){
        this.pointsCalculation();
        console.log(super.displayStudentDetails());
        //usage of the abstract method
        console.log("Points (out of 10) : "+this.points)
    }

}

var studObject = new StudentPointsCalculation(1, "Pavi", 22, 3, ["C1", "C2" , "C3"], [80, 90, 95]);
studObject.displayStudentPoints();
