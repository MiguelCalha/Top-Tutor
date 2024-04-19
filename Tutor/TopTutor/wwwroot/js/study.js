/**
 * Author: Miguel Calha
 * This code initializes a whiteboard using Konva.js, allowing users to draw and erase on it.
 * It includes options to change the drawing tool (draw or erase), select different colors, clear the board, and download the drawing as an image.
 * Grid lines are added to the background for visual reference, and the toolbar is movable within the window.
 */

    let stage;
    let layer;
    let isDrawing = false;
    let lastLine;
    let tool = 'draw';
    let color = '#000000';

    function init() {
        stage = new Konva.Stage({
            container: 'container',
            width: window.innerWidth,
            height: window.innerHeight
        });

    layer = new Konva.Layer();
    stage.add(layer);

    // Add grid lines
    const gridSize = 20;
    for (let i = 0; i < stage.width(); i += gridSize) {
                const line = new Konva.Line({
        points: [i, 0, i, stage.height()],
    stroke: 'rgba(0, 0, 0, 0.1)',
    strokeWidth: 1,
    listening: false
                });
    layer.add(line);
            }
    for (let i = 0; i < stage.height(); i += gridSize) {
                const line = new Konva.Line({
        points: [0, i, stage.width(), i],
    stroke: 'rgba(0, 0, 0, 0.1)',
    strokeWidth: 1,
    listening: false
                });
    layer.add(line);
            }

    stage.on('mousedown touchstart', handleMouseDown);
    stage.on('mousemove touchmove', handleMouseMove);
    stage.on('mouseup touchend', handleMouseUp);
        }

    function handleMouseDown(e) {
            if (tool === 'draw' || tool === 'erase') {
        isDrawing = true;
    const pos = stage.getPointerPosition();
    lastLine = new Konva.Line({
        stroke: tool === 'draw' ? color : '#fff',
    strokeWidth: 5,
    globalCompositeOperation: tool === 'draw' ? 'source-over' : 'destination-out',
    lineCap: 'round',
    lineJoin: 'round',
    points: [pos.x, pos.y]
                });
    layer.add(lastLine);
            }
        }

    function handleMouseMove(e) {
            if (!isDrawing) return;
    const pos = stage.getPointerPosition();
    let newPoints = lastLine.points().concat([pos.x, pos.y]);
    lastLine.points(newPoints);
    layer.batchDraw();
        }

    function handleMouseUp() {
        isDrawing = false;
        }

    function changeTool(selectedTool) {
        tool = selectedTool;
        }

    function changeColor() {
        color = document.getElementById('colorPicker').value;
        }

    function clearBoard() {
        layer.destroyChildren();
    layer.clear();
    stage.clear();
        }

    function downloadImage() {
            const dataURL = stage.toDataURL();
    const link = document.createElement('a');
    link.href = dataURL;
    link.download = 'whiteboard.png';
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
        }

    init();

// JavaScript code to make the toolbar movable
const toolbar = document.getElementById('toolbar');
let isDragging = false;
let offsetX, offsetY;

toolbar.addEventListener('mousedown', (e) => {
    isDragging = true;
    offsetX = e.clientX - toolbar.getBoundingClientRect().left;
    offsetY = e.clientY - toolbar.getBoundingClientRect().top;
});

document.addEventListener('mousemove', (e) => {
    if (isDragging) {
        toolbar.style.left = (e.clientX - offsetX) + 'px';
        toolbar.style.top = (e.clientY - offsetY) + 'px';
    }
});

document.addEventListener('mouseup', () => {
    isDragging = false;
});