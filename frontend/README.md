# amazonClone-react
front(react) back(node) mongoDB
parei em: 01:59:00.

You Will Learn

    HTML5 and CSS3: Semantic Elements, CSS Grid, Flexbox
    React: Components, Props, Events, Hooks, Router, Axios
    Redux: Store, Reducers, Actions
    Node & Express: Web API, Body Parser, File Upload, JWT
    MongoDB: Mongoose, Aggregation
    Development: ESLint, Babel, Git, Github,
    Deployment: Heroku
    Watch React & Node Tutorial

Step by Step for building:

1. Create root folder and create react app
    1. mkdir amazonClone; cd amazonClone
    2. npx create-react-app frontend
    3. Remove unused files
    4. Create the base HTML in App.js
    
2. Share Code On Github 
    1. Initialize git repository (git init) in root folder (amazonClone)
    2. commit changes
    3. login github on local repo
    4. create repo on github
    5. connect local repo to github repo
    6. push changes to github
    
3. Create MainRating and MainCardProduct Component
    1. create src/components/MainRating.js
    2. create div.card-rating in MainRating.js component
    3. style div.card-rating, span and last span
    4. Create src/components/MainCardProduct.js component
    5. use MainRating component in MainCardProduct component
    
4. Build ProductScreen and HomeScreen (pages) in folder screens
    1. install react-router-dom (v6) on frontend folder
    2. use BrowserRouter and make Routes for HomeScreen path: / exact and ProductScreen path product/:id in index.js 
    3. create screens/HomeScreen.js (page)
    4. #HomeScreen: add product list (data.js) code there
    5. create screens/ProductScreen.js (page)
    6. #ProductScreen: add the onClick for singleProduct in home for redirect to path /product/this.id
    7. #ProductScreen: use FLEX GRID and create 3 columns for product-image(col-2), info(col-1) and action/addToCart(col-1)
    
5. Create Node.JS Server
    1. run npm init in root folder (amazonClone)
    2. Update amazonClone/package.json and in last name set "type": "module"
    3. Add .js to imports
    4. npm install express in root folder (amazonClone)
    5. create backend/server.js
    6. npm install nodemon (for auto re-running the aplication) in root folder (amazonClone)
    7. add start command as node backend/server.js in amazonClone/package.json -> scripts -> "start": nodemon --watch backend --exec node --experimental-modules backend/server.js
    8. require express
    9. create route for "/" return "backend is ready." in backend/server.js
    10. move data.js from frontend to backend/server.js
    11. create route for "/api/products" in backend/server.js (GET)
    12. return products
    13. run npm start 
    
6. Load Products from Backend (GET "/api/products") in Frontend (and remove data.js in Frontend)
    1. Change the frontend/package.json -> set "proxy":"http://127.0.0.1:5000"
    2. cd amazonClone/frontend; npm install axios
    3. Edit amazonClone/frontend/src/screens/HomeScreen.js and make:
        1. [products, setProducts] = useState([]);
        2. useEffect() and define async:
            1. get data from "api/products" using axios.get();
            2. set the setProducts.
            3. call the there function in this.
        3. Change and remove data.js in this.
    4. Save All and new terminal -> amazonClone -> npm start and new terminal -> amazonClone/frontend -> npm start (for running the backend and frontend servers)
    5. create frontend/src/components/LoadingBox.js
    6. create frontend/src/components/MessageBox.js
    7. move ALL styles to frontend/src/index.css
    8. use them 2 new components in frontend/src/screens/HomeScreen.js
    9. create a variant class '.alert-danger' and use in MessageBox component from HomeScreen page

7. Install ESlint for code linting (ajuda a manter o padrão no código)
    1. Install VSCode eslint extension
    2. cd amazonClone; npm install -D eslint
    3. run ./node_modules/.bin/eslint --init 
    4. Create ./frontend/.env
    5. Add SKIP_PREFLIGHT_CHECK=true 
    6. CTRL + SHIFT + P -> eslint -> for config eslint 

8. Add Redux to HomeScreen (page)
    1. cd amazonClone/frontend; npm install redux react-redux
    2. create /frontend/src/store.js
        1. initialState = {products: []}
        2. reducer = (state, action) => switch LOAD_PRODUCTS: {products: action.payload}
        3. export default createStore(reducer, initialState)
    3. Wrap with <Provider store={store}> in frontend/src/index.js for injection the store on app 
    4. Install the Redux DevTools extension for browser by developer suport
    5. npm install redux-thunk (thunk = conversão) 
        1. conceituando: https://www.digitalocean.com/community/tutorials/redux-redux-thunk-pt
    5. Edit HomeScreen.js
    6. shopName = useSelector(state => state.products)
    7. const dispatch = useDispatch()
    8. useEffect(() => dispatch({type: LOAD_PRODUCTS, payload: data}))
    9. Add store to index.js