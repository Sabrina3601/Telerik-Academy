/*
 Dependencies
 */

/**
 * Constructor
 * @constructor
 */
var NUMBER_OF_COLS = 8,
	NUMBER_OF_ROWS = 8,
	BLOCK_SIZE = 100;

var BLOCK_COLOUR_1 = '#B58863',
	BLOCK_COLOUR_2 = '#F0D9B5',
	HIGHLIGHT_COLOUR = '#3d1212';

var piecePositions = null;

var start = 25;
    PIECE_PAWN = 0,
	PIECE_CASTLE = 1,
	PIECE_ROUKE = 2,
	PIECE_BISHOP = 3,
	PIECE_QUEEN = 4,
	PIECE_KING = 5,
	IN_PLAY = 0,
	TAKEN = 1,
	pieces = null,
	ctx = null,
	json = null,
	canvas = null,
	BLACK_TEAM = 0,
	WHITE_TEAM = 1,
	SELECT_LINE_WIDTH = 5,
	currentTurn = WHITE_TEAM,
	selectedPiece = null;

function screenToBlock(x, y) {
    var block = {
        "row": Math.floor(y / BLOCK_SIZE),
        "col": Math.floor(x / BLOCK_SIZE)
    };

    return block;
}

function getPieceAtBlockForTeam(teamOfPieces, clickedBlock) {

    var curPiece = null,
		iPieceCounter = 0,
		pieceAtBlock = null;

    for (iPieceCounter = 0; iPieceCounter < teamOfPieces.length; iPieceCounter++) {

        curPiece = teamOfPieces[iPieceCounter];

        if (curPiece.status === IN_PLAY &&
				curPiece.col === clickedBlock.col &&
				curPiece.row === clickedBlock.row) {
            curPiece.position = iPieceCounter;

            pieceAtBlock = curPiece;
            iPieceCounter = teamOfPieces.length;
        }
    }

    return pieceAtBlock;
}

function blockOccupiedByEnemy(clickedBlock) {
    var team = (currentTurn === BLACK_TEAM ? json.white : json.black);

    return getPieceAtBlockForTeam(team, clickedBlock);
}



function blockOccupied(clickedBlock) {
    var pieceAtBlock = getPieceAtBlockForTeam(json.black, clickedBlock);

    if (pieceAtBlock === null) {
        pieceAtBlock = getPieceAtBlockForTeam(json.white, clickedBlock);
    }

    return (pieceAtBlock !== null);
}

function canPawnMoveToBlock(selectedPiece, clickedBlock, enemyPiece) {
    var iRowToMoveTo = (currentTurn === WHITE_TEAM ? selectedPiece.row + 1 : selectedPiece.row - 1),
		bAdjacentEnemy = (clickedBlock.col === selectedPiece.col - 1 ||
					clickedBlock.col === selectedPiece.col + 1) &&
					enemyPiece !== null,
		bNextRowEmpty = (clickedBlock.col === selectedPiece.col &&
					blockOccupied(clickedBlock) === false);

    return clickedBlock.row === iRowToMoveTo &&
			(bNextRowEmpty === true || bAdjacentEnemy === true);
}

function canSelectedMoveToBlock(selectedPiece, clickedBlock, enemyPiece) {
    var bCanMove = false;

    switch (selectedPiece.piece) {

        case PIECE_PAWN:

            bCanMove = canPawnMoveToBlock(selectedPiece, clickedBlock, enemyPiece);

            break;

        case PIECE_CASTLE:

            // TODO

            break;

        case PIECE_ROUKE:

            // TODO

            break;

        case PIECE_BISHOP:

            // TODO

            break;

        case PIECE_QUEEN:

            // TODO

            break;

        case PIECE_KING:

            // TODO

            break;
    }

    return bCanMove;
}

function getPieceAtBlock(clickedBlock) {

    var team = (currentTurn === BLACK_TEAM ? json.black : json.white);

    return getPieceAtBlockForTeam(team, clickedBlock);
}

function getBlockColour(iRowCounter, iBlockCounter) {
    var cStartColour;

    // Chess desk color
    if (iRowCounter % 2) {
        cStartColour = (iBlockCounter % 2 ? BLOCK_COLOUR_1 : BLOCK_COLOUR_2);


    } else {
        cStartColour = (iBlockCounter % 2 ? BLOCK_COLOUR_2 : BLOCK_COLOUR_1);
    }

    return cStartColour;
}

function getBlockBorder(iRowCounter, iBlockCounter) {

    var asd = "black";



    return asd;
}

function drawBlock(iRowCounter, iBlockCounter) {
    // Set the background

    ctx.fillStyle = getBlockColour(iRowCounter, iBlockCounter);
    ctx.strokeStyle = getBlockBorder(iRowCounter, iBlockCounter);
    ctx.lineWidth = 1;

    // Draw rectangle for the background
    ctx.fillRect((iRowCounter * BLOCK_SIZE) + start, (iBlockCounter * BLOCK_SIZE) + start,
		BLOCK_SIZE, BLOCK_SIZE);
    ctx.strokeRect((iRowCounter * BLOCK_SIZE) + start, (iBlockCounter * BLOCK_SIZE) + start,
		BLOCK_SIZE, BLOCK_SIZE);
}


function getImageCoords(pieceCode, bBlackTeam) {

    var imageCoords = {
        "x": pieceCode * BLOCK_SIZE,
        "y": (bBlackTeam ? 0 : BLOCK_SIZE)
    };

    return imageCoords;
}

function drawPiece(curPiece, bBlackTeam) {

    var imageCoords = getImageCoords(curPiece.piece, bBlackTeam);

    // Draw the piece onto the canvas
    ctx.drawImage(pieces,
		imageCoords.x, imageCoords.y,
		BLOCK_SIZE, BLOCK_SIZE,
		(curPiece.col * BLOCK_SIZE) + start, (curPiece.row * BLOCK_SIZE) + start,
		BLOCK_SIZE, BLOCK_SIZE);
}

function drawTeamOfPieces(teamOfPieces, bBlackTeam) {
    var iPieceCounter;

    // Loop through each piece and draw it on the canvas	
    for (iPieceCounter = 0; iPieceCounter < teamOfPieces.length; iPieceCounter++) {
        drawPiece(teamOfPieces[iPieceCounter], bBlackTeam);
    }
}

function drawPieces() {
    drawTeamOfPieces(json.black, true);
    drawTeamOfPieces(json.white, false);
}

function removeSelection(selectedPiece) {
    drawBlock(selectedPiece.col, selectedPiece.row);

    drawPiece(selectedPiece, (currentTurn === BLACK_TEAM));
}

function drawRow(iRowCounter) {
    var iBlockCounter;

    // Draw 8 block left to right
    for (iBlockCounter = 0; iBlockCounter < NUMBER_OF_ROWS; iBlockCounter++) {
        drawBlock(iRowCounter, iBlockCounter);

    }

}

function drawBoard() {
    var iRowCounter;

    for (iRowCounter = 0; iRowCounter < NUMBER_OF_ROWS; iRowCounter++) {
        drawRow(iRowCounter);

    }



    // Draw outline
    ctx.lineWidth = 2;
    ctx.strokeRect(start, start,
		NUMBER_OF_ROWS * BLOCK_SIZE,
		NUMBER_OF_COLS * BLOCK_SIZE);


}
function defaultPositions() {
    json = {
        "white":
			[
				{
				    "piece": PIECE_CASTLE,
				    "row": 0,
				    "col": 0,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_ROUKE,
				    "row": 0,
				    "col": 1,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_BISHOP,
				    "row": 0,
				    "col": 2,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_KING,
				    "row": 0,
				    "col": 3,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_QUEEN,
				    "row": 0,
				    "col": 4,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_BISHOP,
				    "row": 0,
				    "col": 5,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_ROUKE,
				    "row": 0,
				    "col": 6,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_CASTLE,
				    "row": 0,
				    "col": 7,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 0,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 1,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 2,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 3,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 4,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 5,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 6,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 1,
				    "col": 7,
				    "status": IN_PLAY
				}
			],
        "black":
			[
				{
				    "piece": PIECE_CASTLE,
				    "row": 7,
				    "col": 0,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_ROUKE,
				    "row": 7,
				    "col": 1,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_BISHOP,
				    "row": 7,
				    "col": 2,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_KING,
				    "row": 7,
				    "col": 3,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_QUEEN,
				    "row": 7,
				    "col": 4,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_BISHOP,
				    "row": 7,
				    "col": 5,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_ROUKE,
				    "row": 7,
				    "col": 6,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_CASTLE,
				    "row": 7,
				    "col": 7,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 0,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 1,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 2,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 3,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 4,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 5,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 6,
				    "status": IN_PLAY
				},
				{
				    "piece": PIECE_PAWN,
				    "row": 6,
				    "col": 7,
				    "status": IN_PLAY
				}
			]
    };
}

function checkIfPieceClicked(clickedBlock) {
    var pieceAtBlock = getPieceAtBlock(clickedBlock);

    if (pieceAtBlock !== null) {
        selectPiece(pieceAtBlock);
    }
}

function selectPiece(pieceAtBlock) {
    // Draw outline
    ctx.lineWidth = SELECT_LINE_WIDTH;
    ctx.strokeStyle = HIGHLIGHT_COLOUR;
    ctx.strokeRect(((pieceAtBlock.col * BLOCK_SIZE) + SELECT_LINE_WIDTH) + start,
		((pieceAtBlock.row * BLOCK_SIZE) + SELECT_LINE_WIDTH) + start,
		BLOCK_SIZE - (SELECT_LINE_WIDTH * 2),
		BLOCK_SIZE - (SELECT_LINE_WIDTH * 2));

    selectedPiece = pieceAtBlock;
}



function checkIfPieceClicked(clickedBlock) {
    var pieceAtBlock = getPieceAtBlock(clickedBlock);

    if (pieceAtBlock !== null) {
        selectPiece(pieceAtBlock);
    }
}

function movePiece(clickedBlock, enemyPiece) {
    // Clear the block in the original position
    drawBlock(selectedPiece.col, selectedPiece.row);

    var team = (currentTurn === WHITE_TEAM ? json.white : json.black),
		opposite = (currentTurn !== WHITE_TEAM ? json.white : json.black);

    team[selectedPiece.position].col = clickedBlock.col;
    team[selectedPiece.position].row = clickedBlock.row;

    if (enemyPiece !== null) {
        // Clear the piece that you going to take
        drawBlock(enemyPiece.col, enemyPiece.row);
        opposite[enemyPiece.position].status = TAKEN;
    }

    // Draw the piece in the new position
    drawPiece(selectedPiece, (currentTurn === BLACK_TEAM));

    currentTurn = (currentTurn === WHITE_TEAM ? BLACK_TEAM : WHITE_TEAM);

    selectedPiece = null;
}

function processMove(clickedBlock) {
    var pieceAtBlock = getPieceAtBlock(clickedBlock),
		enemyPiece = blockOccupiedByEnemy(clickedBlock);

    if (pieceAtBlock !== null) {
        removeSelection(selectedPiece);
        checkIfPieceClicked(clickedBlock);
    } else if (canSelectedMoveToBlock(selectedPiece, clickedBlock, enemyPiece) === true) {
        movePiece(clickedBlock, enemyPiece);
    }
}

function board_click(ev) {
    var x = ev.clientX - canvas.offsetLeft,
		y = ev.clientY - canvas.offsetTop,
		clickedBlock = screenToBlock(x, y);

    if (selectedPiece === null) {
        checkIfPieceClicked(clickedBlock);
    } else {
        processMove(clickedBlock);
    }
}

function Canvas() {
    this.map = {
        'a8': { x: 0, y: 0 }, 'b8': { x: 100, y: 0 }, 'c8': { x: 200, y: 0 }, 'd8': { x: 300, y: 0 }, 'e8': { x: 400, y: 0 }, 'f8': { x: 500, y: 0 }, 'g8': { x: 600, y: 0 }, 'h8': { x: 700, y: 0 },
        'a7': { x: 0, y: 100 }, 'b7': { x: 100, y: 100 }, 'c7': { x: 200, y: 100 }, 'd7': { x: 300, y: 100 }, 'e7': { x: 400, y: 100 }, 'f7': { x: 500, y: 100 }, 'g7': { x: 600, y: 100 }, 'h7': { x: 700, y: 100 },
        'a6': { x: 0, y: 200 }, 'b6': { x: 100, y: 200 }, 'c6': { x: 200, y: 200 }, 'd6': { x: 300, y: 200 }, 'e6': { x: 400, y: 200 }, 'f6': { x: 500, y: 200 }, 'g6': { x: 600, y: 200 }, 'h6': { x: 700, y: 200 },
        'a5': { x: 0, y: 300 }, 'b5': { x: 100, y: 300 }, 'c5': { x: 200, y: 300 }, 'd5': { x: 300, y: 300 }, 'e5': { x: 400, y: 300 }, 'f5': { x: 500, y: 300 }, 'g5': { x: 600, y: 300 }, 'h5': { x: 700, y: 300 },
        'a4': { x: 0, y: 400 }, 'b4': { x: 100, y: 400 }, 'c4': { x: 200, y: 400 }, 'd4': { x: 300, y: 400 }, 'e4': { x: 400, y: 400 }, 'f4': { x: 500, y: 400 }, 'g4': { x: 600, y: 400 }, 'h4': { x: 700, y: 400 },
        'a3': { x: 0, y: 500 }, 'b3': { x: 100, y: 500 }, 'c3': { x: 200, y: 500 }, 'd3': { x: 300, y: 500 }, 'e3': { x: 400, y: 500 }, 'f3': { x: 500, y: 500 }, 'g3': { x: 600, y: 500 }, 'h3': { x: 700, y: 500 },
        'a2': { x: 0, y: 600 }, 'b2': { x: 100, y: 600 }, 'c2': { x: 200, y: 600 }, 'd2': { x: 300, y: 600 }, 'e2': { x: 400, y: 600 }, 'f2': { x: 500, y: 600 }, 'g2': { x: 600, y: 600 }, 'h2': { x: 700, y: 600 },
        'a1': { x: 0, y: 700 }, 'b1': { x: 100, y: 700 }, 'c1': { x: 200, y: 700 }, 'd1': { x: 300, y: 700 }, 'e1': { x: 400, y: 700 }, 'f1': { x: 500, y: 700 }, 'g1': { x: 600, y: 700 }, 'h1': { x: 700, y: 700 }
    };
    this.init();
}

Canvas.prototype.init = function () {
    canvas = $("#the-canvas")[0];
    console.log("THE CANVAS ", canvas);
    ctx = canvas.getContext("2d");

    //ctx.fillStyle = '#F0D9B5';
    //ctx.fillRect(25, 25, 800, 800);
    //ctx.strokeRect(25, 25, 800, 800);
    //ctx.fillStyle = '#B58863';

    //for (var i = 25; i < 800; i += 100) {
    //    for (var j = 25; j < 800; j += 100) {
    //        if ((i % 200 === 25 && j % 200 === 25) || (i % 200 === 125 && j % 200 === 125)) {
    //            ctx.fillRect(i, j, 100, 100);
    //            ctx.strokeRect(i, j, 100, 100);
    //        }
    //    }
    //}

    //signs
    ctx.fillStyle = 'grey';
    ctx.font = '30px Consolas';
    ctx.fillText('A', 70, 22);
    ctx.fillText('B', 170, 22);
    ctx.fillText('C', 270, 22);
    ctx.fillText('D', 370, 22);
    ctx.fillText('E', 470, 22);
    ctx.fillText('F', 570, 22);
    ctx.fillText('G', 670, 22);
    ctx.fillText('H', 770, 22);

    ctx.fillText('8', 0, 85);
    ctx.fillText('7', 0, 185);
    ctx.fillText('6', 0, 285);
    ctx.fillText('5', 0, 385);
    ctx.fillText('4', 0, 485);
    ctx.fillText('3', 0, 585);
    ctx.fillText('2', 0, 685);
    ctx.fillText('1', 0, 785);

    //BLOCK_SIZE = canvas.height / NUMBER_OF_ROWS;

    // Draw the background
   // drawBoard();
    drawBoard();
    defaultPositions();

    // Draw pieces
    pieces = new Image();
    pieces.src = 'img/pieces.png';
    pieces.onload = drawPieces;

    canvas.addEventListener('click', board_click, false);
};



