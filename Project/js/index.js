function myFunction() {
  document.getElementById("myDropdown").classList.toggle("show");
}

var button = document.querySelector('.anotherjoke');
let tellJoke = document.querySelector(".telljoke")
writeJoke();
function writeJoke() {
{
  tellJoke.innerHTML = "Loading...";
  fetch('https://v2.jokeapi.dev/joke/Programming').then(response => {
    if (!response.ok) {
        throw new Error();
    }
    return response.json();
    }).then(sleeper(4000))
    .then(data => {
      if(data['type'] == "single") {
        tellJoke.innerHTML = data['joke'];
      }else {
        tellJoke.innerHTML = data['setup'] + "<br><br>";
        setTimeout(function() {
          tellJoke.innerHTML += data['delivery'];
        }, 4000)
      }
  })
  .catch(function (error) {
    tellJoke.innerText = "An error has occurred, please try again in a few moments";
  });
}
}

button.addEventListener("click", writeJoke);
function sleeper(ms) {
return function(response) {
  return new Promise(resolve => setTimeout(() => resolve(response), ms));
};
}

// Extra Credit Button Three. Make screen disappear for 5 secs.
var card = document.getElementById("buttonthree");
function screenGone() {
card.style.visibility = "hidden";
setTimeout(screenBack(), 5000);
}
function screenBack() {
return function() {
  card.style.visibility = "visible";
}
}
// Extra credit to make Card fade in and out when Button 4 is pressed.
function magic() {
var blink = document.getElementById("card");
blink.classList.toggle("blinking");
}

// Change the background color when Button 1 is clicked.
function randomButtonColor() {
let colors = ["#ffd0d2","#fffdd0","#d0fffd","#d0d2ff"];
document.getElementsByTagName('body')[0].style.background = "linear-gradient(90deg, "+colors[randomNumber(0,4)]+" "+"50%, "+colors[randomNumber(0,4)] + ")";
}
function randomNumber(min,max) {
return Math.floor((Math.random() * max) + min);
}
// Make the button turn upside down.
function rotate() {
var rotate = document.getElementById("buttontwo");
rotate.classList.toggle("rotate");
}