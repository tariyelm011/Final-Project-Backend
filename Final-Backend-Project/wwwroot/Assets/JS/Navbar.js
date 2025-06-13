document.addEventListener('DOMContentLoaded', function() {
    const openSidebarBtn = document.getElementById('openSidebarBtn');
    const closeSidebarBtn = document.getElementById('closeSidebarBtn');
    const sidebarMenu = document.getElementById('sidebarMenu');
    let backdrop;
    function openSidebar() {
      sidebarMenu.classList.add('show');
      backdrop = document.createElement('div');
      backdrop.className = 'offcanvas-backdrop';
      document.body.appendChild(backdrop);
      setTimeout(() => {
        backdrop.classList.add('show');
      }, 50);
      backdrop.addEventListener('click', closeSidebar);
      document.body.style.overflow = 'hidden';
    }
    function closeSidebar() {
      sidebarMenu.classList.remove('show');
      if (backdrop) {
        backdrop.classList.remove('show');
        setTimeout(() => {
          backdrop.remove();
        }, 300);
      }
      document.body.style.overflow = '';
    }
    if (openSidebarBtn) {
      openSidebarBtn.addEventListener('click', openSidebar);
    }
    if (closeSidebarBtn) {
      closeSidebarBtn.addEventListener('click', closeSidebar);
    }
    const expandBtns = document.querySelectorAll('.expand-btn');
    expandBtns.forEach(btn => {
      btn.addEventListener('click', function() {
        const icon = this.querySelector('i');
        if (icon.classList.contains('bi-plus')) {
          icon.classList.remove('bi-plus');
          icon.classList.add('bi-dash');
        } else {
          icon.classList.remove('bi-dash');
          icon.classList.add('bi-plus');
        }
      });
    });
  });
const targetElement = document.querySelector('.navbar');

window.addEventListener('scroll', () => {
  if (window.scrollY >= 150) {
    targetElement.classList.add('sticky');
    targetElement.style.padding ="5px 0"
  } else {
    targetElement.classList.remove('sticky');
    targetElement.style.padding ="15px 0"

  }
});
const searchmenu = document.querySelector('.sub-search');
function hiddensearch() {
  searchmenu.classList.add('hidden')
}
function shownsearch() {
  searchmenu.classList.remove('hidden')
}