function solve(coordinates) {
    function isInside(matrix, targetRow, targetCol) {
        return targetRow < matrix.length && targetRow >= 0 && targetCol >= 0 && targetCol < matrix[targetRow].length;
    }
    
    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            console.log(matrix[row].join('\t'));
        }
    }
    
    function lookingForWinner(matrix, playerSymbol) {
        let winner = false;
        if (matrix[0][0] === playerSymbol && matrix[0][1] === playerSymbol && matrix[0][2] == playerSymbol) {
            winner = true;
        } else if (matrix[0][0] === playerSymbol && matrix[1][1] === playerSymbol && matrix[2][2] === playerSymbol) {
            winner = true;
        } else if (matrix[0][0] === playerSymbol && matrix[1][0] === playerSymbol && matrix[2][0] === playerSymbol) {
            winner = true;
        } else if (matrix[0][1] === playerSymbol && matrix[1][1] === playerSymbol && matrix[2][1] === playerSymbol) {
            winner = true;
        } else if (matrix[0][2] === playerSymbol && matrix[1][2] === playerSymbol && matrix[2][2] === playerSymbol) {
            winner = true;
        } else if (matrix[1][0] === playerSymbol && matrix[1][1] === playerSymbol && matrix[1][2] === playerSymbol) {
            winner = true;
        } else if (matrix[2][0] === playerSymbol && matrix[2][1] === playerSymbol && matrix[2][2] === playerSymbol) {
            winner = true;
        } else if (matrix[2][0] === playerSymbol && matrix[1][1] === playerSymbol && matrix[0][2] === playerSymbol) {
    
        }
        return winner;
    }
    
    function isThereFreeSpace(matrix) {
        let freeSpace = false;
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {
                if (matrix[row][col] == false) {
                    freeSpace = true;
                }
            }
        }
        return freeSpace;
    }
    let theMatrix = [];
    for (let index = 0; index < 3; index++) {
        theMatrix[index] = [];
        for (let sec = 0; sec < 3; sec++) {
            theMatrix[index].push(false);
        }
    }
    let firstPlayerTurn = true;

    for (let index = 0; index < coordinates.length; index++) {
        let currCoordinates = coordinates[index].split(' ').map(Number);
        let targetRow = currCoordinates[0];
        let targetCol = currCoordinates[1];

        if (!isThereFreeSpace(theMatrix)) {
            break;
        }

        if (isInside(theMatrix, targetRow, targetCol) && theMatrix[targetRow][targetCol] !== false) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }

        if (firstPlayerTurn && isInside(theMatrix, targetRow, targetCol)) {
            theMatrix[targetRow][targetCol] = 'X';
            firstPlayerTurn = false;
            if (lookingForWinner(theMatrix, 'X')) {
                console.log('Player X wins!');
                break;
            }
        } else if (!firstPlayerTurn && isInside(theMatrix, targetRow, targetCol)) {
            theMatrix[targetRow][targetCol] = 'O';
            firstPlayerTurn = true;
            if (lookingForWinner(theMatrix, 'O')) {
                console.log('Player O wins!');
                break;
            }
        }
    }
    if (!lookingForWinner(theMatrix, 'X') && !lookingForWinner(theMatrix, 'O')) {
        console.log('The game ended! Nobody wins :(');
    }

    printMatrix(theMatrix);
}



solve(['0 0',
    '0 0',
    '1 1',
    '0 1',
    '1 2',
    '0 2',
    '2 2',
    '1 2',
    '2 2',
    '2 1']);