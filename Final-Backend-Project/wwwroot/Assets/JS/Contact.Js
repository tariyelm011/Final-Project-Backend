document.getElementById('phone').addEventListener('input', function (e) {
    this.value = this.value.replace(/[^\d+]/g, '');
  });