//Task1 
//Write a method that from a given array of students 
//finds all students whose first name is before its last 
//name alphabetically. Print the students in 
//descending order by full name. Use Underscore.js
function Person(firstName, lastName, age, marks) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.marks = marks;
};

var people = [
    new Person("Doncho", "Minkov", 10, 2),
    new Person("Ivailo", "Kenov", 22,3),
    new Person("Nikolay", "Kostov" , 33,4),
    new Person("Svetlin", "Nakov",44,5),
    new Person("Moq", "Milost", 88, 6),
    new Person("Ivailo", "Ivanov", 55, 5),
    new Person("Petar", "Ivanov", 66, 3)
];
console.log("------------------Students whose first name is before its last name alphabetically------------------");

var filtered = _.filter(people, function (p) {
    return p.firstName < p.lastName;
})

filtered.forEach(function (people) {
    console.log(people.firstName + ' ' + people.lastName);
});

//Task2
//Write function that finds the first name and last 
//name of all students with age between 18 and 24. 
//Use Underscore.js
console.log("------------------Students between 18 and 24------------------");
var ageSort = _.filter(people, function (p) {
    return p.age > 18 && p.age < 24;
});

ageSort.forEach(function(people){
    console.log(people.firstName + ' ' + people.lastName);
})

//Task 3
//Write a function that by a given array of students 
//finds the student with highest marksconsole.log("------------------Finds the student with highest marks------------------");var highestMark = _.max(people, function (p) {
    return p.marks;
});

console.log(highestMark.firstName + ' ' + highestMark.lastName);

//Task4
//Write a function that by a given array of animals, 
//groups them by species and sorts them by number of 
//legs
console.log("------------------Groups animals by species and sorts them by number of legs------------------");


function Animal(name, species, legs) {
    this.name = name;
    this.species = species;
    this.legs = legs;
};

var animals = [
    new Animal("Dog", "mammal", 4),
    new Animal("Cat", "mammal", 4),
    new Animal("Mosquito", "insect", 6),
    new Animal("Human", "mammal", 2),
    new Animal("Dolphin", "mammal", 0),
    new Animal("Parrot", "bird", 2),
    new Animal("Pigeot", "bird", 2),
    new Animal("Butterfly", "insect", 6)
];

var grouped = _.groupBy(animals, function (a) {
    return a.species;
});

for (var a in grouped) {
    grouped[a] = _.sortBy(grouped[a], function (animal) {
        return animal.legs;
    })
}

for (var animal in grouped) {
    grouped[animal].forEach(function (a) {
        console.log(a.name + ' - ' + a.species + ' - ' + a.legs + " legs")
    })
}

//Task5 
//By a given array of animals, find the total number of 
//legs
//Each animal can have 2, 4, 6, 8 or 100 legs
console.log("------------------Total number of legs------------------");

var legsAnimals = _.reduce(animals, function (memo, a) {
    return memo + a.legs;
},0);
console.log(legsAnimals + '  is total number of legs');

//Task6
//By a given collection of books, find the most popular 
//author (the author with the highest number of 
//books)function Book(name, author) {
    this.name = name;
    this.author = author;
};

var books = [
    new Book("Intorduction to C#", "Svetlin Nakov"),
    new Book("Norwegian Wood", "Marukami"),
    new Book("A Game Of Thrones", "George R.R. Martin"),
    new Book("Intorduction to Java", "Svetlin Nakov"),
    new Book("A Game Of Thrones part 2", "George R.R. Martin"),
    new Book("A Game Of Thrones part 3", "George R.R. Martin")
];
console.log("------------------Most popular author------------------");
var author = _.countBy(books, function (book) {
    return book.author;
});

var mostPopular = _.max(author, function (book) {
    return book;
});

for (var a in author) {
    if (author[a] === mostPopular) {
        console.log(a)
    }
}

//Task7 
//By an array of people find the most common first and 
//last name. Use underscore.

console.log("------------------Find the most common first and last name------------------");
var mostCommonFirstName = _.countBy(people, function (p) {
    return p.firstName;
});

var index = _.max(mostCommonFirstName, function (p) {
    return p;
});

mostCommonFirstName = _.invert(mostCommonFirstName);
console.log("most comon first name " + mostCommonFirstName[index]);


var mostCommonLastName = _.countBy(people, function (p) {
    return p.lastName;
});

var index = _.max(mostCommonLastName, function (p) {
    return p;
});

mostCommonLastName = _.invert(mostCommonLastName);
console.log("most comon last name " + mostCommonLastName[index]);