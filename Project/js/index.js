

var button = document.querySelector('.anotherjoke');
writeJoke();
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
function writeJoke() {
  {
    fetch('https://geek-jokes.sameerkumar.website/api').then(response => response.json()).then(sleeper(4000))
      .then(data => {
        let joke = document.querySelector(".telljoke")
        joke.innerHTML = data;
    })
    .catch(function (error) {
        // display a message in the joke container to 
      let joke = document.querySelector(".telljoke")
      joke.innerText = "An error has occurred, please try again in a few moments";
    });
  }
}

/* button.addEventListener("click", function() {
  axios({
    method: 'get',
    url: 'https://geek-jokes.sameerkumar.website/api',
    responseType: 'stream'
  })
    .then(sleeper(5000)).then(function(response) {
      let joke = document.querySelector(".telljoke")
      joke.innerText = response.data;
    })}); */

    button.addEventListener("click", writeJoke);



    function sleeper(ms) {
      return function(response) {
        return new Promise(resolve => setTimeout(() => resolve(response), ms));
      };
    }

/* 
button.addEventListener("click", function() {
  fetch('https://geek-jokes.sameerkumar.website/api').then(response => response.json())
  .then(data => {
    let joke = document.querySelector(".telljoke")
    joke.innerHTML = data;
  })
}) */

/* function myFunction() {
  document.getElementsById("drop").classList.toggle("show");
}
    
window.onclick = function(event) {
  if(!event.target.matches('menu')) {
    var dropdowns - document.getElementsByClassName("dropdownoption");
    for(var i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}
     */
    
    





    