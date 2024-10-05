// Get modal element
const modal = document.getElementById("myModal");
const btn = document.getElementById("openModal");
const span = document.getElementById("closeModal");

// Open the modal
btn.onclick = function () {
    modal.style.display = "block";
}

// Close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// Close the modal when clicking outside of it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

//GSAP
var tl = gsap.timeline({
    scrollTrigger: {
        trigger: ".header2",
        start: "0% 90%",
        end: "50% 75%",
        scrub: true,
        //markers:true,
    }
})

tl.to("#car", {
    top: "88%",
    left: "-19%",
    scale: 0.3,
    duration: 1
})

// Animate the wheels
tl.to("#wheel", {
    y: -50, // Move it up
    opacity: 0, // Fade out
    duration: .1
}, "<"); // "<" makes it start at the same time as the previous animation

tl.to("#wheel1", {
    y: -50, // Move it up
    opacity: 0, // Fade out
    duration: 0.1
}, "<");



// Car Image Slider 
function changeImage(element) {
    document.getElementById("img").src = element.src;
}