    // Wait for the DOM to be ready
    document.addEventListener('DOMContentLoaded', function () {
        // Get the checkbox and form elements
        var checkbox = document.getElementById('myCheckbox');
        var form = document.getElementById('myForm');

        // Add an event listener to the checkbox
        checkbox.addEventListener('change', function () {
            // Check if the checkbox is checked
            if (checkbox.checked) {

            Swal.fire({
                title: 'Switch to public account?',
                text: "Anyone can see your posts, reels, and stories, and can use your original audio.",
                icon: 'warning',
                showCancelButton: true,
                backdrop: `rgba(60,60,60,0.8)`,
                confirmButtonText: 'Yes, delete it!',
                confirmButtonColor: "#c03221"
            }).then((result) => {
                if (result.isConfirmed) {
                    // Trigger form submission
                    form.submit();
                } else {
                    // If user cancels, revert the checkbox change
                    checkbox.checked = !checkbox.checked;
                }
            });
        });
        }
        else
        {
            Swal.fire({
                title: 'Switch to private account?',
                text: "Anyone can not see your posts, reels, and stories, and can use your original audio.",
                icon: 'warning',
                showCancelButton: true,
                backdrop: `rgba(60,60,60,0.8)`,
                confirmButtonText: 'Yes, delete it!',
                confirmButtonColor: "#c03221"
            }).then((result) => {
                if (result.isConfirmed) {
                    // Trigger form submission
                    form.submit();
                } else {
                    // If user cancels, revert the checkbox change
                    checkbox.checked = !checkbox.checked;
                }
            });
        });
        }
        

        // Add an event listener to the form submit
        form.addEventListener('submit', function (event) {
            event.preventDefault();
            // Perform any additional form handling here
        });
    });