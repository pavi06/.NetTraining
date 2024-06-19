var quotes = [];
var currentQuotes = [];
//items to display per page
const itemsPerPage = 5;
var currentPage = 1;
var totalPages ;

//to fetch all the quotes from the api
var fetchQuotes = () => {
    fetch('https://dummyjson.com/quotes', {
        method: 'GET',
    })
    .then(res => res.json()
    )
    .then( data => {
        quotes = data.quotes;
        currentQuotes=[...quotes];
        //display first page 
        displayQuotes();
    })
    .catch(error => {
        console.error(error);
    });
};

function displayQuotes() {
    const quoteContainer = document.getElementById('items');
    const start = (currentPage - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    totalPages = Math.ceil(currentQuotes.length / itemsPerPage);
    const paginatedQuotes = currentQuotes.slice(start, end);
    var quotesRetrieved = "";
    paginatedQuotes.forEach(quoteEle => {
        quotesRetrieved+= `
        <div class="item">
            <div class="card-body">
                <blockquote class="blockquote mb-0">
                    <p>${quoteEle.quote}</p>
                    <p style="font-size:18px;color:#6F53CA"><i>${quoteEle.author}</i></p>
                </blockquote>
            </div>
        </div>
        `;
    });
    quoteContainer.innerHTML=quotesRetrieved;
    document.getElementById('pageNo').innerHTML=`page ${currentPage} of ${totalPages}`;
    renderPagination();
}

function renderPagination() {
    const pageButtons = document.getElementById('pageButtons');
    pageButtons.innerHTML = '';

    //to create button based on the number of pages
    for (let i = 1; i <= totalPages; i++) {
        const btn = document.createElement('button');
        btn.textContent = i;
        btn.id = `btn-${i}`;
        btn.onclick = () => {
            btnClicked(i);
        };
        btn.classList.add('btn');
        btn.classList.add('btnStyle');
        pageButtons.appendChild(btn);
    }
    //to disable the prev and next button based on the currentpage
    document.getElementById('prevBtn').disabled = currentPage === 1;
    document.getElementById('nextBtn').disabled = currentPage === totalPages;
}

var btnClicked =(i)=>{
    currentPage = i;
    displayQuotes();
}

//function to move previous page
function prevPage() {
    if (currentPage > 1) {
        currentPage--;
        displayQuotes();
    }
}

//function to move next page
function nextPage() {
    const totalPages = Math.ceil(currentQuotes.length / itemsPerPage);
    if (currentPage < totalPages) {
        currentPage++;
        displayQuotes();
    }
}

// Initial fetch and display
document.addEventListener('DOMContentLoaded', function() {
    fetchQuotes();
});


//filtering quotes by author
var GetQuotes = () =>{
    // document.getElementById('searchBtn').classList.add('activeBtn');
    var author = document.getElementById("authorName").value.trim();
    var quotesOfAuthor=[];
    if(author){
        quotes.forEach(element => {
            if(element.author.toLowerCase() === author.toLowerCase()){
                quotesOfAuthor.push(element);
            }
        })
        currentQuotes=[...quotesOfAuthor];
        displayQuotes()
    }
    else{
        currentQuotes=[...quotes];
        displayQuotes();
    }
}

//sorting quotes by author
var GetSortedQuotes = () =>{
    currentQuotes = [...quotes];
    currentQuotes.sort((a, b) => {
        if (a.author.toLowerCase() < b.author.toLowerCase()) return -1;
        if (a.author.toLowerCase() > b.author.toLowerCase()) return 1;
        return 0;
    });
    displayQuotes();
}
