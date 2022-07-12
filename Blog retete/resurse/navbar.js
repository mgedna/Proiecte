const links = document.getElementById("link-meniu") 
const navBtnDOM = document.getElementById("meniu") 

navBtnDOM.addEventListener('click', () => {
  links.classList.toggle('show-links')
})  