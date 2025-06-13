const fromInput = document.getElementById("priceFrom");
const toInput = document.getElementById("priceTo");

const blockKeys = ["e", "+", "-"];

[fromInput, toInput].forEach(input => {
  input.addEventListener("keydown", function (e) {
    if (blockKeys.includes(e.key)) {
      e.preventDefault();
    }
  });
});

toInput.addEventListener("input", function () {
  const fromVal = parseFloat(fromInput.value);
  const toVal = parseFloat(toInput.value);

  if (!isNaN(fromVal) && toVal <= fromVal) {
    toInput.setCustomValidity("To value must be greater than From value");
  } else {
    toInput.setCustomValidity("");
  }
});
const submenu = document.querySelector('.shop-product-submenu');
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

function hiddenbtn() {
    submenu.classList.add('hidden')
}
function showbtn() {
    submenu.classList.remove('hidden')
}
  
