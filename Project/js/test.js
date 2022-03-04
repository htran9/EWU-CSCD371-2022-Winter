function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
}
  
  // Close the dropdown if the user clicks outside of it
  window.onclick = function(event) {
    if (!event.target.matches('.dropbtn')) {
      var dropdowns = document.getElementsByClassName("dropdown-content");
      var i;
      for (i = 0; i < dropdowns.length; i++) {
        var openDropdown = dropdowns[i];
        if (openDropdown.classList.contains('show')) {
          openDropdown.classList.remove('show');
        }
      }
    }
}

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
