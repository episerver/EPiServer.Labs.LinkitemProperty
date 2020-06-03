define([
    "dojo/_base/declare",
    "dojo/_base/lang",
    "dojo/aspect",
    "epi-cms/widget/_SelectorBase",
    "epi-cms/contentediting/command/ItemEdit",
    "epi-cms/contentediting/viewmodel/LinkItemModel",
    "episerver-labs-linkitem-property/widget/extended-link-editor"
], function (
    declare,
    lang,
    aspect,
    _SelectorBase,
    ItemEditCommand,
    LinkItemModel,
    ExtendedLinkEditor
) {
    return declare([_SelectorBase], {
        postMixInProperties: function () {

            this.inherited(arguments);

            if (this.customTypeIdentifier) {
                this.allowedDndTypes.unshift(this.customTypeIdentifier);
            }
        },

        postCreate: function () {
            this.inherited(arguments);

            if (!this.value) {
                this._updateDisplayNode(null);
            }
            this._editItemCommand = this._createCommand();
            this.own(this._createCommand(ItemEditCommand));
        },

        _createCommand: function () {
            var dialogContentParams = this.commandOptions ? this.commandOptions.dialogContentParams : {};

            var command = new ItemEditCommand({
                isAvailable: true,
                canExecute: true,
                model: this.model,
                dialogContentParams: dialogContentParams,
                dialogContentClass: ExtendedLinkEditor
            });

            this.own(
                aspect.after(command, "onDialogOpen", function () {
                    this.set("isShowingChildDialog", true);
                    this.focus();
                }.bind(this)),
                aspect.after(command, "onDialogHideComplete", function () {
                    this.set("isShowingChildDialog", false);
                }.bind(this)),
                aspect.after(command, "onDialogExecute", function () {
                    this.set("value", [this._editItemCommand.value]);
                    this.onChange(this.value);
                }.bind(this))

            );

            return command;
        },

        _setValueAttr: function (value) {
            if (!value || (value instanceof Array) && value.length === 0) {
                this._set("value", []);
                this._updateDisplayNode(null);
                return;
            } else if (value && !(value instanceof Array)) {
                // handle D&D on overlay, the value will be single item
                value = [this._createItemFromDropData(value)];
            }

            this._set("value", value);
            this._updateDisplayNode({ name: value[0].text });
        },

        _onButtonClick: function () {
            // summary:
            //    Triggered when editor clicks on link edit button
            //    Overriden from _SelectorBase
            //
            // tags:
            //    public callback

            if (this.value && (this.value instanceof Array && this.value.length > 0)) {
                this._editItemCommand.set("value", this.value[0]);
            } else {
                this._editItemCommand.set("value", {});
            }
            this._editItemCommand.execute();
        },

        getEmptyValue: function () {
            // summary:
            //    Returns empty property value
            //    Overriden from _HasClearButton
            //
            // tags:
            //    public callback
            return [];
        },

        clearValue: function () {
            // summary:
            //    Triggered when editor clicks clear buton
            //    Overriden from _HasClearButton
            //
            // tags:
            //    public callback

            this.inherited(arguments);
            this.onChange(this.value);
        },

        onDrop: function (value) {
            // summary:
            //    Triggered when something has been dropped onto the widget.
            //    Overriden from _Droppable
            //
            // tags:
            //    public callback

            //this.focus();
            //var item = this._createItemFromDropData(value);

            //this.set("value", [item]);
            this.onChange(this.value);
        },

        _createItemFromDropData: function (value) {
            var id = { id: new Date().getTime().toString() };
            var linkItem = new LinkItemModel(lang.mixin(lang.clone(value), id));
            return linkItem.serialize();
        },

        _setSelectedContentNameAttr: function (value) {
            // summary:
            //		Sets the display name for selected content
            //      Overrides _SelectorBase
            // tags:
            //    protected

            if (value) {
                this.selectedContentNameNode.innerHTML =
                    "<span class='dijitInline dijitIcon epi-iconLink epi-objectIcon'></span>&nbsp;" + value;
                this._updateDisplayNodeTitle();
            } else {
                this.inherited(arguments);
            }
        }
    });
});
