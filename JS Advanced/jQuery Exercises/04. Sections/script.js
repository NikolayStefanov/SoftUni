function create(words) {
   words.forEach(element => {
      var newParagraph = $('<p>').text(element).hide();
      var newSection = $('<div>').append(newParagraph).click(showSection);
      
      $('#content').append(newSection);
   });
}
function showSection(){
   if($(this).find('p').is(':visible')){
      $(this).find('p').hide();
   }else{
   $(this).find('p').show();
   }
}