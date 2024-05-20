<?php 
function student(){ ?>
  <div class="card mt-3">
    <div class="card-header">
      <h4 class="mb-0">List of Students</h4>
    </div>
    <div class="card-body" id="studentList">
      <div class="table-responsive mb-3" id="listStudent">
        <table class="table table-bordered table-striped">
          <thead>
            <tr>
              <th>Id</th>
              <th>First Name</th>
              <th>Middle Name</th>
              <th>Last Name</th>
              <th>Age</th>
              <th>Gender</th>
              <th>Campus</th>
              <th>Department</th>
              <th>Course</th>
              <th>Major</th>
              <th>Status</th>
              <th>Year</th>
              <th>...</th>
            </tr>
          </thead>
          <tbody id="studentTableBody">
            <!-- Data will be injected here by JavaScript -->
          </tbody>
        </table>
      </div>
    </div>
  </div>

  <script>
    document.addEventListener('DOMContentLoaded', function() {
      fetch('http://localhost:3000/api/personal-info')
        .then(response => response.json())
        .then(data => {
          const tableBody = document.getElementById('studentTableBody');
          data.forEach(student => {
            const row = document.createElement('tr');
            row.innerHTML = `
              <td>${student.personal_id}</td>
              <td>${student.firstname}</td>
              <td>${student.middlename}</td>
              <td>${student.lastname}</td>
              <td>${student.age}</td>
              <td>${student.sex}</td>
              <td>${student.campus}</td>
              <td>${student.department}</td>
              <td>${student.course}</td>
              <td>${student.major}</td>
              <td>${student.status}</td>
              <td>${student.year}</td>
              <td>...</td>
            `;
            tableBody.appendChild(row);
          });
        })
        .catch(error => {
          console.error('Error fetching student data:', error);
        });
    });
  </script>
<?php } ?>
