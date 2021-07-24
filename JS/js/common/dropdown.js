var dropdown = document.querySelector(".dropdown-department");
    var dropdownList = document.querySelector(".dropdown-list-department");
    var iconDown = document.querySelector(".icon-down-department");
    var dropdownValue = document.querySelector(".dropdown-value-department");
    var state = false;

    var currVal = 0;



    var dropdownData = [
        "Tất cả phòng ban",
        "Phòng đào tạo",
        "Phòng maketting",
        "Phòng dự án"
    ];
    render_dep();

    function render_dep() {
        var dropdownListHTML = '';
        dropdownValue.innerText = dropdownData[currVal];

        for (var i = 0; i < dropdownData.length; i++) {
            if (i != currVal) {
                dropdownListHTML += `<li data-id=${i} class="dropdown-item"> ${dropdownData[i]} </li>`;
            } else {
                dropdownListHTML += `<li data-id=${i} class="dropdown-item active"> ${dropdownData[i]} </li>`;
            }
        }

        dropdownList.innerHTML = dropdownListHTML;

        var items = dropdownList.querySelectorAll('.dropdown-item');

        items.forEach((item) => {
            item.addEventListener('click', () => {
                var dataId = item.getAttribute('data-id');
                this.currVal = dataId;
                this.render_dep();
                console.log(dropdownList);
            });
        });

    }

    dropdown.addEventListener('click', function() {
        dropdownList.classList.toggle('show');
        iconDown.classList.toggle('move-up');
    });
