document.querySelectorAll('.footer-toggle-icon').forEach(icon => {
    icon.addEventListener('click', () => {
      const parentColumn = icon.closest('.col-12');
      const currentAttachment = parentColumn.querySelector('.footer-attachment');
      const isVisible = currentAttachment.classList.contains('show');
      document.querySelectorAll('.footer-attachment').forEach(attachment => {
        attachment.classList.remove('show');
      });
      document.querySelectorAll('.footer-toggle-icon').forEach(i => {
        i.textContent = '+';
      });
      if (!isVisible) {
        currentAttachment.classList.add('show');
        icon.textContent = '−';
      }
    });
  });
