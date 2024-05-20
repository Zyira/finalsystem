// index.js
const express = require('express');
const personalrouter = require('./routes/personalInfoRoutes');
const accountrouter = require('./routes/personalAccountRoutes');
const bodyParser = require('body-parser');
const cors = require('cors');

const app = express();
const port = 3000;

app.use(bodyParser.json());
app.use(cors());

// Corrected route setup
app.use('/api', personalrouter);
app.use('/acc', accountrouter);

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
