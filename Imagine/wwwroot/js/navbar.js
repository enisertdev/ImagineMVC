// Modern E-commerce Navigation Scripts
document.addEventListener('DOMContentLoaded', function () {
    // Sticky Header
    const header = document.querySelector('.header-area');
    let lastScroll = 0;

    window.addEventListener('scroll', () => {
        const currentScroll = window.pageYOffset;

        if (currentScroll <= 0) {
            header.classList.remove('scroll-up');
            return;
        }

        if (currentScroll > lastScroll && !header.classList.contains('scroll-down')) {
            // Scroll Down
            header.classList.remove('scroll-up');
            header.classList.add('scroll-down');
        } else if (currentScroll < lastScroll && header.classList.contains('scroll-down')) {
            // Scroll Up
            header.classList.remove('scroll-down');
            header.classList.add('scroll-up');
        }
        lastScroll = currentScroll;
    });

    // Search Input Animation
    const searchInput = document.querySelector('.search-input');

    searchInput.addEventListener('focus', () => {
        searchInput.parentElement.classList.add('focused');
    });

    searchInput.addEventListener('blur', () => {
        searchInput.parentElement.classList.remove('focused');
    });

    // Dropdown Hover Effect
    const dropdowns = document.querySelectorAll('.dropdown');

    dropdowns.forEach(dropdown => {
        dropdown.addEventListener('mouseenter', function () {
            if (window.innerWidth >= 992) {
                const dropdownMenu = this.querySelector('.dropdown-menu');
                dropdownMenu.classList.add('show');
            }
        });

        dropdown.addEventListener('mouseleave', function () {
            if (window.innerWidth >= 992) {
                const dropdownMenu = this.querySelector('.dropdown-menu');
                dropdownMenu.classList.remove('show');
            }
        });
    });

    // Mobile Menu Toggle Animation
    const navbarToggler = document.querySelector('.navbar-toggler');

    navbarToggler.addEventListener('click', function () {
        this.classList.toggle('active');
    });

    // Cart and Wishlist Counter Updates (Example)
    function updateCounter(selector, count) {
        const counter = document.querySelector(selector);
        if (counter) {
            counter.textContent = count;
            counter.classList.add('pulse');
            setTimeout(() => counter.classList.remove('pulse'), 1000);
        }
    }

    // Example usage:
    // updateCounter('.cart-count', 5);
    // updateCounter('.wishlist-count', 3);
});