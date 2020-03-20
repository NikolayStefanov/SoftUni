let theUrl = 'https://studentsremotedatabase.firebaseio.com/';
let tBodyRef = document.querySelector("#results > tbody");
let idInp = document.querySelector("#data-id");


let id = nextId();



function solve() {
    document.querySelector("body > form > button").addEventListener('click', postStudent)
    idInp.disabled = true;
    idInp.value = id;
    document.querySelector("#extractAll").addEventListener('click', extractStrudents)
}

function nextId(){
    if (tBodyRef.children.length > 0) {
        let nextId = tBodyRef.lastChild.firstChild.textContent;
        return (+nextId+1)
    }else{
        return 1;
    }
    
}
async function extractStrudents(e) {
    try {
        let response = await fetch(theUrl + 'students.json');
        if (response.ok) {
            let data = await response.json();
            if (data) {
                tBodyRef.innerHTML = '';
                Object.entries(data).filter(x => x[1]).forEach(([key, value]) => {
                    let htmlObj = {
                        id: value.id,
                        firstName: value.firstName,
                        lastName: value.lastName,
                        facultyNumber: value.facultyNumber,
                        grade: value.grade
                    }
                    let newTr = generateHTML(htmlObj);
                    tBodyRef.appendChild(newTr);
                    
                    id = nextId();
                    idInp.value = id;
                    
                });

            } else {
                tBodyRef.innerHTML = '';
                throw new Error('There is no students!')
            }

        } else {
            throw Error('The problem is in RESPONSE')
        }
    } catch (error) {
        console.error(error)

    }



}
async function postStudent(e) {
    e.preventDefault();
    let parrentNode = e.target.parentNode;

    let firstName = parrentNode.querySelector('#firstName')
    let lastName = parrentNode.querySelector('#lastName')
    let facNumber = parrentNode.querySelector('#facultyNumber')
    let grade = parrentNode.querySelector('#grade')
    let theGrade = +grade.value;

    let newStudent = createStudent(id, firstName.value, lastName.value, facNumber.value, theGrade)

    if (newStudent) {
        firstName.value = '';
        lastName.value = '';
        facNumber.value = '';
        grade.value = '';

        await fetch(theUrl + `students/${id}.json`, {
            method: 'PATCH',
            body: JSON.stringify(newStudent)
        });

        extractStrudents();
        
        document.querySelector("#data-id").value = ++id;
    }

}

function generateHTML(student) {
    let tempTr = document.createElement('tr');

    for (const key in student) {
        let newTd = document.createElement('td');
        newTd.textContent = student[key];
        tempTr.appendChild(newTd);
    }

    return tempTr;

}

function createStudent(id, firstName, lastName, facultyNum, grade) {

    try {
        let facultyRegExCheck = numericCheckFunc(facultyNum);
        if (!firstName || !lastName || typeof (grade) !== 'number' || !grade || !facultyRegExCheck) {
            if (!facultyRegExCheck) {
                let errorMess = 'Must be string of NUMBERS';
                document.querySelector("#facultyNumber").value = errorMess;
                document.querySelector("#facultyNumber").style.color = 'red'
            }
            throw new Error('INCORRECT PARAMETERS')
        }
        document.querySelector("#facultyNumber").style.color = 'black'
        let newStudent = {
            id: id,
            firstName: firstName,
            lastName: lastName,
            facultyNumber: facultyNum,
            grade: grade

        }
        return newStudent;
    } catch (error) {
        console.error(error);
    }
};

function numericCheckFunc(stringNum) {
    let myRegExp = RegExp(/^\b[0-9]+\b$/, 'g')
    return myRegExp.test(stringNum)
}
solve();