document.getElementById("loanForm").addEventListener("submit", async (e) => {
  e.preventDefault();

  const amount = parseFloat(document.getElementById("loanAmount").value);
  const rate = parseFloat(document.getElementById("interestRate").value);

  const response = await fetch("https://localhost:5001/api/loan/offers", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ loanAmount: amount, interestRate: rate })
  });

  const offers = await response.json();
  renderOffers(offers);
});

function renderOffers(offers) {
  const container = document.getElementById("offersContainer");
  container.innerHTML = "";

  offers.forEach(offer => {
    const colorClass = getColorClass(offer.monthlyPayment);
    const card = document.createElement("div");
    card.className = "col-md-4";
    card.innerHTML = `
      <div class="card ${colorClass} shadow-sm">
        <div class="card-body">
          <h5 class="card-title">${offer.years} év</h5>
          <p class="card-text">Havi törlesztő: <strong>${offer.monthlyPayment.toLocaleString()} Ft</strong></p>
          <p class="card-text">Teljes visszafizetés: ${offer.totalRepayment.toLocaleString()} Ft</p>
        </div>
      </div>
    `;
    container.appendChild(card);
  });
}

function getColorClass(monthly) {
  if (monthly < 100000) return "green";
  if (monthly < 200000) return "yellow";
  return "red";
}