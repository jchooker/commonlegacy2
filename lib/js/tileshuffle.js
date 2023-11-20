$(function () {
    deployScene();
});

function deployScene() {
    //scene setup
    var scene = new THREE.Scene();

    //camera setup
    var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    camera.position.z = 5;

    //renderer setup
    var renderer = new THREE.WebGLRenderer();
    renderer.setSize(window.innerWidth, window.innerHeight);
    $('#threejscontainer').append(renderer.domElement);

    //group of 3js objs
    var group = new THREE.Group();

    //'tile' geometry
    var tileGeometry = new THREE.BoxGeometry(1, 1, 1);
    var radius = 0.1;
    var tileMaterial = new THREE.MeshBasicMaterial({ color: 0xffffff });
    var tileMesh = new THREE.Mesh(tileGeometry, tileMaterial);
    group.add(tileMesh);

    //adding png files on top of "tiles"
    var fileLocs = [];
    var obj = $.getJSON('./json/imgurls1.json', (data) => {
        $.each(data, (index, item) => {
            fileLocs.push(item);
        });
    });
    const fileLocTest = 'https://i.ibb.co/vV6CJM4/asmodeus.png';
    var textureLoader = new THREE.TextureLoader();
    var texture = textureLoader.load(fileLocTest);


    var imgGeometry = new THREE.PlaneGeometry(1, 1);
    var imgMaterial = new THREE.MeshBasicMaterial({ map: texture, transparent: true });
    var imgMesh = new THREE.Mesh(imgGeometry, imgMaterial);
    imgMesh.position.y = 0.5;
    //tileMesh.add(imgMesh);
    group.add(imgMesh);
    scene.add(group);

    var dragControls = new THREE.DragControls([group], camera, renderer.domElement);

    dragControls.addEventListener('drag', function (event) {
        // You can perform custom actions during dragging
        console.log('Group dragged');
    });

    camera.position.z = 5;
    animate();
}

function animate() {
    requestAnimationFrame(animate);
    renderer.render(scene, camera);
}