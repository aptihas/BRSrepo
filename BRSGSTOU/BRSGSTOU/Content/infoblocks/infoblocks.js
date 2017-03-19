/*
/*	Created by Dzhamiev Nur-Magomed, Vargo Vinch
/*	http://vargovinch.com/
/*	2015, All Right Reserved
/*	using jQuery
*/

function deleteInfoBlock(e){
	$(e).parent().parent().fadeOut('fast',function(){$(this).detach()});
}

function delCreatedBlock(e){
	e.fadeOut('slow',function(){e.detach()});
};

function createInfoBlock(autoclose,loader,text){
	loader?l='<img id="loader" src="infoblocks/images/loading.gif" />':l=getTime();
	var block = '<div class="info">'+text+'</div>';
	$('#fixed_con').append(block);
	$('#fixed_con').show();
	var $block = $('#fixed_con div.info:last-child');
	$block.fadeIn('fast');
	if(autoclose!=0) setTimeout(function(){
		$block.fadeOut('slow',function(){
			$block.detach();
			if($('#fixed_con').html() == '') $('#fixed_con').hide();
		});

	},autoclose*1000);
	return $block;
}

function getTime(){
	var a = new Date();
		h = a.getHours();
		m = a.getMinutes();
		s = a.getSeconds();
		text = '<span class="info_time">'+tn(h)+':'+tn(m)+':'+tn(s)+'</span>';
	return text;
}

function tn(n){n<10?r='0'+n:r=n; return r};