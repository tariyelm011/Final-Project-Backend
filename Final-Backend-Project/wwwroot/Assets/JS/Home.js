document.querySelectorAll('.card-img-top').forEach(img => {
    img.addEventListener('mouseenter', () => {
        const sibling = img.closest('.produsts-items').querySelector('.hidden');
        if (sibling) {
            sibling.style.display = 'block';
        }
    });

    img.addEventListener('mouseleave', () => {
        const sibling = img.closest('.produsts-items').querySelector('.hidden');
        if (sibling) {
            sibling.style.display = 'none';
        }
    });
});

const container = document.querySelector('.products-title');
const buttons = container.querySelectorAll('ul li button');

buttons.forEach(button => {
    button.addEventListener('click', () => {
        const activeBtn = container.querySelector('button.activbtn');
        if (activeBtn) activeBtn.classList.remove('activbtn');

        button.classList.add('activbtn');
    });
});
document.addEventListener('DOMContentLoaded', function () {
    const slider = document.getElementById('cardSlider');
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');
    const cardItems = document.querySelectorAll('.card-item');
    let position = 0;
    let itemWidth = cardItems[0].offsetWidth;
    let visibleItems = Math.floor(slider.parentElement.offsetWidth / itemWidth);
    window.addEventListener('resize', function () {
        itemWidth = cardItems[0].offsetWidth;
        visibleItems = Math.floor(slider.parentElement.offsetWidth / itemWidth);
        updateSliderPosition();
    });
    nextBtn.addEventListener('click', function () {
        const maxPosition = cardItems.length - visibleItems;
        if (position < maxPosition) {
            position++;
            updateSliderPosition();
        }
    });
    prevBtn.addEventListener('click', function () {
        if (position > 0) {
            position--;
            updateSliderPosition();
        }
    });
    function updateSliderPosition() {
        slider.style.transform = `translateX(-${position * itemWidth}px)`;
        prevBtn.disabled = position === 0;
        const maxPosition = cardItems.length - visibleItems;
        nextBtn.disabled = position >= maxPosition;
    }
    updateSliderPosition();
});

const targetDate = new Date("2025-07-31T23:59:59").getTime();
const countdown = setInterval(function () {
    let now = new Date().getTime();
    let distance = targetDate - now;
    if (distance <= 0) {
        document.querySelector(".countdown-day").textContent = "00";
        document.querySelector(".countdown-hour").textContent = "00";
        document.querySelector(".countdown-minunt").textContent = "00";
        document.querySelector(".countdown-second").textContent = "00";
        clearInterval(countdown);
        return;
    }
    let days = Math.floor(distance / (1000 * 60 * 60 * 24));
    let hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    let seconds = Math.floor((distance % (1000 * 60)) / 1000);
    document.querySelector(".countdown-day").textContent = days.toString().padStart(2, "0");
    document.querySelector(".countdown-hour").textContent = hours.toString().padStart(2, "0");
    document.querySelector(".countdown-minunt").textContent = minutes.toString().padStart(2, "0");
    document.querySelector(".countdown-second").textContent = seconds.toString().padStart(2, "0");
}, 1000);

const img = document.getElementById('myImage');
const target = document.getElementById('otherElement');

function updateMarginTop() {
  const height = img.offsetHeight;
  target.style.marginTop = `calc(calc(calc(${height}px+100px)/2)*(-1))`;
}
if (img.complete) {
  updateMarginTop();
} else {
  img.onload = () => {
    updateMarginTop();
  };
}

window.addEventListener('resize', updateMarginTop);