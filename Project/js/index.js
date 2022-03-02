

var button = document.querySelector('.anotherjoke');
/* button.addEventListener("click", function() {
  axios({
    method: 'get',
    url: 'https://geek-jokes.sameerkumar.website/api',
    responseType: 'stream'
  })
    .then(function(response) {
      let joke = document.querySelector(".telljoke")
      joke.innerText = response.data;
    })}); */


    button.addEventListener("click", function() {
      fetch('https://geek-jokes.sameerkumar.website/api').then(response => response.json())
      .then(data => {
        let joke = document.querySelector(".telljoke")
        joke.innerHTML = data;
      })
    })

    
    
    
    





    