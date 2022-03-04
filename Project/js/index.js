var button = document.querySelector('.anotherjoke');
writeJoke();
function writeJoke() {
  {
    let joke = document.querySelector(".telljoke")
    joke.innerHTML = "Loading...";
    fetch('https://geek-jokes.sameerkumar.website/api').then(response => response.json()).then(sleeper(4000))
      .then(data => {
        let joke = document.querySelector(".telljoke")
        joke.innerHTML = data;
    })
    .catch(function (error) {
      let joke = document.querySelector(".telljoke")
      joke.innerText = "An error has occurred, please try again in a few moments";
    });
  }
}
button.addEventListener("click", writeJoke);
function sleeper(ms) {
  return function(response) {
    return new Promise(resolve => setTimeout(() => resolve(response), ms));
  };
}
function showMenu() {
  var drop = document.getElementById("drop");
  drop.classList.toggle("hidden");
}

// Extra Credit Button Three. Make screen disappear for 5 secs.
var card = document.getElementById("card");
function screenGone() {
  card.style.visibility = "hidden";
  setTimeout(screenBack(), 5000);
}
function screenBack() {
  return function() {
    card.style.visibility = "visible";
  }
}
    

/* function writeJoke() {
  {
    axios({
      method: 'get',
      url: 'https://geek-jokes.sameerkumar.website/api',
      responseType: 'ms-stream'
    })
      .then(sleeper(4000)).then(function(response) {

        let joke = document.querySelector(".telljoke")
        joke.innerText = response.data;
      })
      .catch(function (error) {
        // display a message in the joke container to 
        let joke = document.querySelector(".telljoke")
        joke.innerText = "An error has occurred, please try again in a few moments";
    });
  }
} */