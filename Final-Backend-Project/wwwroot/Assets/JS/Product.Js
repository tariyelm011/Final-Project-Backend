document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('.quantity').forEach(function (container) {
      const display = container.querySelector('.qty-display');
      const increment = container.querySelector('.increment');
      const decrement = container.querySelector('.decrement');
  
      let count = parseInt(display.textContent, 10);
  
      increment.addEventListener('click', function () {
        count++;
        display.textContent = count;
      });
  
      decrement.addEventListener('click', function () {
        if (count > 1) {
          count--;
          display.textContent = count;
        }
      });
    });
  });
  