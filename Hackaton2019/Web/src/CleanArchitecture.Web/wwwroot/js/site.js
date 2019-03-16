$(document)
    .on("show.bs.modal",
        ".modal",
        function () {
            var zIndex = 1040 + (10 * $(".modal:visible").length);
            $(this).css("z-index", zIndex);
            setTimeout(function () {
                $(".modal-backdrop").not(".modal-stack").css("z-index", zIndex - 1).addClass("modal-stack");
            },
                0);
        });
var opcionesFormaModal = {
    beforeSubmit: prepararPeticion,
    success: ejecutarRespuesta,
    error: mostrarError
};
var opcionesFormaModalOld = {
    beforeSubmit: prepararPeticion,
    success: ejecutarRespuestaOld,
    error: mostrarError
};

var opcionesForma = {
    beforeSubmit: prepararPeticion,
    success: ejecutarRespuestaForma,
    error: mostrarError
};


function prepararPeticion(arr, $form, options) {
    // valida la forma, si pasa continua el submit
    $form.validate();
    var button = $form.find('button[type="submit"]');
    $form.find(".modal-errores").html("");

    if ($form.valid()) {
        monoloading('show');
        button.prop("disabled", true);
    } else {
        Console.log("error");
        $form.find(".modal-errores").html("Error");
        button.prop("disabled", false);
        return false;
    }
}
function ejecutarRespuesta(responseText, statusText, xhr, $form) {
    var json = responseText;
    var $modal = $form.parents(".modal");

    $modal.find('button[type="submit"]').prop("disabled", false);
    monoloading('hide');

    $modal.find(".modal-errores").html("");
    if (json.status === "ok") {
        $modal.modal('hide');
        monotoast(json.body);
        document.getElementsByClassName('datatable')[document.getElementsByClassName('datatable').length - 1].ej2_instances[0].refresh();
    } else {
        $modal.find(".modal-errores").html(`<p>${json.body}</p>`);
    }
}
function mostrarError(xhr, statusText, errorThrown, $form) {
    $form.find('[type="submit"]').prop("disabled", false);
    monoloading('hide');
    if (xhr.status === 401) {
        $form.find(".modal-errores")
            .html("<p>Tu sesión caducó, por favor <a href='/' target='_blank'>inicia sesión</a> e intenta de nuevo</p>");
    } else if (xhr.status === 500) {
        $form.find(".modal-errores")
            .html("<p>Ocurrió un error en el servidor</p>");
    } else {
        $form.find(".modal-errores")
            .html("<p>Ocurrió un error inesperado</p>");
    }
}
$(document)
    .on("shown.bs.modal",
        ".modal",
        function () {
            if ($(this).find('.select2') !== 'undefined') {
                $(this).find('.select2').each(function (i, obj) {
                    var $select = $(obj);
                    if (typeof $select.attr("placeholder") !== 'undefined') {
                        $select.select2({
                            placeholder: $select.attr('placeholder'),
                            allowClear: true
                        });
                    } else {
                        $select.select2();
                    }
                });

            }
        });

$(document)
    .on("hidden.bs.modal",
        ".modal",
        function (event) {
            if ($(".modal").hasClass("show")) {
                $("body").addClass("modal-open");
            }
        });

$(document)
    .on("hide.bs.modal",
        ".modal",
        function (event) {
            if ($(this).find('.datatable-server-side').length > 0) {
                $dataTables.pop();
            }
        });

// carga un modal por ajax y lo pone en el DOM, activa la forma si es que tiene
$(document).on("click",
    ".btn-modal-action",
    function (e) {
        e.preventDefault();
        var $btn = $(this);
        var modalId = $btn.attr("href");
        var $modal = $(modalId);
        var url = $modal.data("url");
        var $container = $modal;
        var id = $btn.data("id");

        if (typeof id != "undefined") {
            url = url + "/" + id;
        }

        //monoloading("show");
        $.get(url,
            function (data) {
                //monoloading("hide");
                $container.html(data);

                if ($container.find('.datatable-server-side').length > 0) {
                    activarDatatable($container.find('.datatable-server-side'));
                }

                if ($container.find('.datatable').length > 0) {
                    activarDatatableVanilla();
                }

                var $form = $modal.find("form");
                if (!$.isEmptyObject($form)) {
                   // $.validator.unobtrusive.parse($form);
                }
                $container.find(".forma-ajax--modal").ajaxForm(opcionesFormaModal);
                $container.find(".forma-ajax--modal-refresh").ajaxForm(opcionesFormaModalOld);

                $modal.modal("show");
            }).fail(mostrarErrorSnack);
    });

function mostrarErrorSnack() {
    //monoloading('hide');
    monotoast("Ocurrió un error inesperado");
}
function ejecutarRespuestaOld(responseText, statusText, xhr, $form) {
    var json = responseText;
    var $modal = $form.parents(".modal");

    $modal.find(".modal-errores").html("");
    if (json.status === "ok") {
        Cookies.set("consola-toast", json.body);
        window.location.reload();
    } else {
        monoloading('hide');
        $modal.find('button[type="submit"]').prop("disabled", false);
        $modal.find(".modal-errores").html(`<p>${json.body}</p>`);
    }
}
function ejecutarRespuestaForma(responseText, statusText, xhr, $form) {
    var json = responseText;

    $form.find('button[type="submit"]').prop("disabled", false);
    monoloading('hide');

    $form.find(".modal-errores").html("");
    if (json.status === "ok") {
        $form.resetForm();
        monotoast(json.body);
    } else {
        $form.find(".modal-errores").html(`<p>${json.body}</p>`);
    }
}
