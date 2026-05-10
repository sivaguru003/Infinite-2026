// 1. Area of Triangle
let a = 5;
let b = 6;
let c = 7;
let s = (a + b + c) / 2;
let area = Math.sqrt(s * (s - a) * (s - b) * (s - c));
console.log("Area of Triangle = " + area);

// 2. Star Pattern
console.log("Star Pattern");
let rows = 5;
for (let i = 1; i <= rows; i++) {
    let star = "";
    for (let j = 1; j <= i; j++) {
        star += "* ";
    }
    console.log(star);
}

// 3. Leap Year Program
let year = 2024;
if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) {
    console.log(year + " is a Leap Year");
}
else {
    console.log(year + " is not a Leap Year");
}

// 4. Days Left Until Independence Day
let today = new Date();
let currentYear = today.getFullYear();
let independenceDay = new Date(currentYear, 7, 15);
if (today > independenceDay) {
    independenceDay = new Date(currentYear + 1, 7, 15);
}
let difference = independenceDay - today;
let daysLeft = Math.ceil(difference / (1000 * 60 * 60 * 24));
console.log("Days Left Until Independence Day = " + daysLeft);