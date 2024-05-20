<?php 
function dashboard() { ?>
  <div class="container-xxl flex-grow-1 container-p-y">
    <div class="row">
      <div class="col-md-12">
        <div class="card mb-4">
          <hr class="my-0" />
          <div class="card-body">
            <div class="app-brand justify-content-center">
              <a class="app-brand-link gap-2">
                <h4 class="fw-bold py-3 mb-4">
                  <span class="text-muted fw-light">
                    <i class="menu-icon tf-icons bx bx-pen"></i>
                  </span> Kindly Fill Up
                </h4>
              </a>
            </div>
            <form id="formAuthentication" class="mb-3">
              <div class="row">
                <div class="mb-3 col-md-6">
                  <label for="Fname" class="form-label">First Name</label>
                  <input class="form-control" type="text" name="fName" id="Fname" placeholder="Enter your First Name" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="Lname" class="form-label">Last Name</label>
                  <input class="form-control" type="text" name="lName" id="Lname" placeholder="Enter your Last Name" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="Mname" class="form-label">Middle Name</label>
                  <input class="form-control" type="text" name="middleName" id="Mname" placeholder="Enter your Middle Name" />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="age" class="form-label">Age</label>
                  <input class="form-control" type="text" name="age" id="age" placeholder="Enter your Age" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="sex" class="form-label">Sex/Gender</label>
                  <select id="sex" name="sex" class="select2 form-select" required>
                    <option value="">Select Sex</option>
                    <option value="Female">Female</option>
                    <option value="Male">Male</option>
                  </select>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="campus" class="form-label">Campus</label>
                  <select id="campus" name="campus" class="select2 form-select" required>
                    <option value="">Select Campus</option>
                    <option value="SanJuan">San Juan</option>
                    <option value="Bontoc">Bontoc</option>
                    <option value="TomasOppus">Tomas Oppus</option>
                    <option value="Maasin">Maasin</option>
                    <option value="MainSogod">Main Sogod</option>
                    <option value="Hinunangan">Hinunangan</option>
                  </select>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="department" class="form-label">Department</label>
                  <input type="text" class="form-control" name="department" id="Department" placeholder="Enter your Department" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="course" class="form-label">Course</label>
                  <input type="text" name="course" id="Course" class="form-control" placeholder="Enter your Course" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="major" class="form-label">Major</label>
                  <input type="text" class="form-control" id="major" name="major" placeholder="Major" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="status" class="form-label">Status</label>
                  <select id="status" name="status" class="select2 form-select" required>
                    <option value="">Select Status</option>
                    <option value="Continue">Continue</option>
                    <option value="UnderGraduate">Under Graduate</option>
                    <option value="Transferee">Transferee</option>
                    <option value="Graduate">Graduate</option>
                  </select>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="year" class="form-label">Year</label>
                  <input type="text" class="form-control" id="year" name="year" placeholder="Enter your Year" required />
                </div>
              </div>
              <div class="mt-2">
                <button type="submit" class="btn btn-primary me-2">Save changes</button>
                <button type="reset" class="btn btn-outline-secondary">Cancel</button>
              </div>
            </form>
          </div>
        </div>
      </div>
      <script>
    document.getElementById('formAuthentication').addEventListener('submit', function(event) {
        event.preventDefault(); // Prevent default form submission

        // Capture form data
        const firstname = document.getElementById('Fname').value;
        const lastname = document.getElementById('Lname').value;
        const middlename = document.getElementById('Mname').value;
        const age = document.getElementById('age').value;
        const sex = document.getElementById('sex').value;
        const campus = document.getElementById('campus').value;
        const department = document.getElementById('Department').value;
        const course = document.getElementById('Course').value;
        const major = document.getElementById('major').value;
        const status = document.getElementById('status').value;
        const year = document.getElementById('year').value;


        // Construct the book object
        const book = {
           firstname :firstname,
           lastname :lastname,
           middlename:middlename,
           age :age,
           sex :sex,
           campus :campus,
           department :department,
           course :course,
           major :major,
           status :status,
           year :year,
        };

        // Call the API to add the book
        fetch('http://localhost:3000/api/personal-info', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(book)
        })
        .then(response => response.json())
        .then(data => {
            console.log(data); // For debugging purposes
            if (data.success) {
                alert('Book added successfully with ID: ' + data.insertId);
                // Optionally, reset the form or redirect to another page
                document.getElementById('formAuthentication').reset();
            } else {
                document.getElementById('formAuthentication').reset();
            }
        })
        .catch(error => {
            console.error('Error adding book:', error);
            alert('Failed to add book. Please try again.');
        });
    });
    </script>

    </div>
  </div>
<?php } ?>
